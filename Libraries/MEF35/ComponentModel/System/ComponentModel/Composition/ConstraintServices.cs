// -----------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.Internal;

namespace System.ComponentModel.Composition
{
    internal static class ConstraintServices
    {
        // NOTE : these are here as Reflection member search is pretty expensive, and we want that to be done once.
        // Also, making these static would cause this class to fail loading if we rename members of ExportDefinition.
        private static readonly PropertyInfo _exportDefinitionContractNameProperty = typeof(ExportDefinition).GetProperty("ContractName");
        private static readonly PropertyInfo _exportDefinitionMetadataProperty = typeof(ExportDefinition).GetProperty("Metadata");
        private static readonly MethodInfo _metadataContainsKeyMethod = typeof(IDictionary<string, object>).GetMethod("ContainsKey");
        private static readonly MethodInfo _metadataItemMethod = typeof(IDictionary<string, object>).GetMethod("get_Item");
        private static readonly MethodInfo _metadataEqualsMethod = typeof(object).GetMethod("Equals", new Type[] { typeof(object) });

        public static Expression<Func<ExportDefinition, bool>> CreateConstraint(IEnumerable<string> requiredMetadata)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(ExportDefinition), "exportDefinition");
            Expression metadataConstraintBody = null;

            if (requiredMetadata != null)
            {
                metadataConstraintBody = ConstraintServices.CreateMetadataConstraintBody(requiredMetadata, parameter);
            }

            if (metadataConstraintBody != null)
            {
                return Expression.Lambda<Func<ExportDefinition, bool>>(metadataConstraintBody, parameter);
            }
            
            return null;
        }

        public static Expression<Func<ExportDefinition, bool>> CreateConstraint(string contractName, string requiredTypeIdentity, IEnumerable<string> requiredMetadata, CreationPolicy requiredCreationPolicy)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(ExportDefinition), "exportDefinition");

            Expression constraintBody = ConstraintServices.CreateContractConstraintBody(contractName, parameter);

            if (!string.IsNullOrEmpty(requiredTypeIdentity))
            {
                Expression typeIdentityConstraintBody = ConstraintServices.CreateTypeIdentityContraint(requiredTypeIdentity, parameter);

                constraintBody = Expression.AndAlso(constraintBody, typeIdentityConstraintBody);
            }

            if (requiredMetadata != null)
            {
                Expression metadataConstraintBody = ConstraintServices.CreateMetadataConstraintBody(requiredMetadata, parameter);
                if (metadataConstraintBody != null)
                {
                    constraintBody = Expression.AndAlso(constraintBody, metadataConstraintBody);
                }
            }

            if (requiredCreationPolicy != CreationPolicy.Any)
            {
                Expression policyConstraintBody = ConstraintServices.CreateCreationPolicyContraint(requiredCreationPolicy, parameter);

                constraintBody = Expression.AndAlso(constraintBody, policyConstraintBody);
            }

            Expression<Func<ExportDefinition, bool>> constraint = Expression.Lambda<Func<ExportDefinition, bool>>(constraintBody, parameter);
            return constraint;
        }

        private static Expression CreateContractConstraintBody(string contractName, ParameterExpression parameter)
        {
            Assumes.NotNull(parameter);

            // export.ContractName=<contract>;
            return Expression.Equal(
                    Expression.Property(parameter, ConstraintServices._exportDefinitionContractNameProperty),
                    Expression.Constant(contractName ?? string.Empty, typeof(string)));
        }

        private static Expression CreateMetadataConstraintBody(IEnumerable<string> requiredMetadata, ParameterExpression parameter)
        {
            Assumes.NotNull(requiredMetadata);
            Assumes.NotNull(parameter);

            Expression body = null;
            foreach (string requiredMetadataItem in requiredMetadata)
            {
                // export.Metadata.ContainsKey(<metadataItem>)
                Expression metadataItemExpression = CreateMetadataContainsKeyExpression(parameter, requiredMetadataItem);

                body = (body != null) ? Expression.AndAlso(body, metadataItemExpression) : metadataItemExpression;
            }

            return body;
        }

        private static Expression CreateCreationPolicyContraint(CreationPolicy policy, ParameterExpression parameter)
        {
            Assumes.IsTrue(policy != CreationPolicy.Any);
            Assumes.NotNull(parameter);

            //    !definition.Metadata.ContainsKey(CompositionConstants.PartCreationPolicyMetadataName) ||
            //        CreationPolicy.Any.Equals(definition.Metadata[CompositionConstants.PartCreationPolicyMetadataName]) ||
            //        policy.Equals(definition.Metadata[CompositionConstants.PartCreationPolicyMetadataName]);

            return  Expression.MakeBinary(ExpressionType.OrElse,
                        Expression.MakeBinary(ExpressionType.OrElse,
                            Expression.Not(CreateMetadataContainsKeyExpression(parameter, CompositionConstants.PartCreationPolicyMetadataName)),
                            CreateMetadataValueEqualsExpression(parameter, CreationPolicy.Any, CompositionConstants.PartCreationPolicyMetadataName)),
                        CreateMetadataValueEqualsExpression(parameter, policy, CompositionConstants.PartCreationPolicyMetadataName));
        }

        private static Expression CreateTypeIdentityContraint(string requiredTypeIdentity, ParameterExpression parameter)
        {
            Assumes.NotNull(requiredTypeIdentity);
            Assumes.NotNull(parameter);

            //    definition.Metadata.ContainsKey(CompositionServices.ExportTypeIdentity) &&
            //        requiredTypeIdentity.Equals(definition.Metadata[CompositionConstants.ExportTypeIdentityMetadataName]);

            return  Expression.MakeBinary(ExpressionType.AndAlso,
                        CreateMetadataContainsKeyExpression(parameter, CompositionConstants.ExportTypeIdentityMetadataName),
                        CreateMetadataValueEqualsExpression(parameter, requiredTypeIdentity, CompositionConstants.ExportTypeIdentityMetadataName));
        }

        private static Expression CreateMetadataContainsKeyExpression(ParameterExpression parameter, object constantKey)
        {
            Assumes.NotNull(parameter, constantKey);

            // definition.Metadata.ContainsKey(constantKey)
            return  Expression.Call(
                        Expression.Property(parameter, ConstraintServices._exportDefinitionMetadataProperty),
                        ConstraintServices._metadataContainsKeyMethod,
                        Expression.Constant(constantKey));
        }

        private static Expression CreateMetadataValueEqualsExpression(ParameterExpression parameter, object constantValue, string metadataName)
        {
            Assumes.NotNull(parameter, constantValue);

            // constantValue.Equals(definition.Metadata[CompositionServices.PartCreationPolicyMetadataName])
            return  Expression.Call(
                        Expression.Constant(constantValue),
                        ConstraintServices._metadataEqualsMethod,
                        Expression.Call(
                            Expression.Property(parameter, ConstraintServices._exportDefinitionMetadataProperty),
                            ConstraintServices._metadataItemMethod,
                            Expression.Constant(metadataName)));
        }

        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            Assumes.NotNull(left);
            if (right == null)
                return left;

            ParameterExpression parameter = Expression.Parameter(left.Parameters[0].Type, left.Parameters[0].Name);
            Expression body = Expression.AndAlso(Expression.Invoke(left, parameter), Expression.Invoke(right, parameter));
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }
}
