// -----------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition.ReflectionModel;
using System.Linq;
using System.Reflection;
using Microsoft.Internal;
using Microsoft.Internal.Collections;
using System.Diagnostics;

namespace System.ComponentModel.Composition.AttributedModel
{
    internal static class AttributedModelDiscovery
    {
        private static readonly Type ExportType = typeof(Export);
        public static ComposablePartDefinition CreatePartDefinitionIfDiscoverable(Type type, ICompositionElement origin)
        {
            if (type.IsAttributeDefined<PartNotDiscoverableAttribute>())
            {
                return null;
            }

            AttributedPartCreationInfo creationInfo = new AttributedPartCreationInfo(type, null, false, origin);

            if (!creationInfo.IsPartDiscoverable())
            {
                return null;
            }

            return new ReflectionComposablePartDefinition(creationInfo);
        }

        public static ReflectionComposablePartDefinition CreatePartDefinition(Type type, PartCreationPolicyAttribute partCreationPolicy, bool ignoreConstructorImports, ICompositionElement origin)
        {
            Assumes.NotNull(type);

            AttributedPartCreationInfo creationInfo = new AttributedPartCreationInfo(type, partCreationPolicy, ignoreConstructorImports, origin);

            return new ReflectionComposablePartDefinition(creationInfo);
        }

        public static ReflectionComposablePart CreatePart(object attributedPart)
        {
            Assumes.NotNull(attributedPart);

            // If given an instance then we want to pass the default composition options because we treat it as a shared part
            // TODO: ICompositionElement Give this def an origin indicating that it was added directly to the MutableExportProvider.

            ReflectionComposablePartDefinition definition = AttributedModelDiscovery.CreatePartDefinition(attributedPart.GetType(), PartCreationPolicyAttribute.Shared, true, (ICompositionElement)null);

            return new ReflectionComposablePart(definition, attributedPart);
        }

        public static ReflectionParameterImportDefinition CreateParameterImportDefinition(ParameterInfo parameter, ICompositionElement origin)
        {
            Requires.NotNull(parameter, "parameter");

            ReflectionParameter reflectionParameter = parameter.ToReflectionParameter();

            AttributedImportDefinitionCreationInfo importCreationInfo = AttributedModelDiscovery.GetImportDefinitionCreationInfo(reflectionParameter, parameter);
            return new ReflectionParameterImportDefinition(
                parameter.AsLazy(), 
                importCreationInfo.ContractName,
                importCreationInfo.RequiredTypeIdentity,
                importCreationInfo.RequiredMetadata, 
                importCreationInfo.Cardinality, 
                importCreationInfo.RequiredCreationPolicy,
                origin);
        }

        public static ReflectionMemberImportDefinition CreateMemberImportDefinition(MemberInfo member, ICompositionElement origin)
        {
            Requires.NotNull(member, "member");

            ReflectionWritableMember reflectionMember = member.ToReflectionWritableMember();

            AttributedImportDefinitionCreationInfo importCreationInfo = AttributedModelDiscovery.GetImportDefinitionCreationInfo(reflectionMember, member);
            return new ReflectionMemberImportDefinition(
                new LazyMemberInfo(member), 
                importCreationInfo.ContractName, 
                importCreationInfo.RequiredTypeIdentity,
                importCreationInfo.RequiredMetadata, 
                importCreationInfo.Cardinality, 
                importCreationInfo.IsRecomposable, 
                importCreationInfo.RequiredCreationPolicy,
                origin);
        }

        //
        // Import definition creation helpers
        //
        private static AttributedImportDefinitionCreationInfo GetImportDefinitionCreationInfo(ReflectionItem item, ICustomAttributeProvider attributeProvider)
        {
            Assumes.NotNull(item, attributeProvider);

            AttributedImportDefinitionCreationInfo importCreationInfo = new AttributedImportDefinitionCreationInfo();

            IAttributedImport attributedImport = AttributedModelDiscovery.GetAttributedImport(item, attributeProvider);
            ImportType importType = new ImportType(item.ReturnType, attributedImport.Cardinality);

            DisplayDebugWarnings(attributedImport.Cardinality, item, importType);

            importCreationInfo.RequiredMetadata = importType.IsLazy ?
                    CompositionServices.GetRequiredMetadata(importType.LazyType.MetadataViewType) :
                    Enumerable.Empty<string>();
            importCreationInfo.Cardinality = attributedImport.Cardinality;
            importCreationInfo.ContractName = attributedImport.GetContractNameFromImport(importType);
            importCreationInfo.RequiredTypeIdentity = attributedImport.GetTypeIdentityFromImport(importType);
            importCreationInfo.IsRecomposable = (item.ItemType == ReflectionItemType.Parameter) ? false : attributedImport.AllowRecomposition;
            importCreationInfo.RequiredCreationPolicy = attributedImport.RequiredCreationPolicy;

            return importCreationInfo;
        }

        private static IAttributedImport GetAttributedImport(ReflectionItem item, ICustomAttributeProvider attributeProvider)
        {
            IAttributedImport[] imports = attributeProvider.GetAttributes<IAttributedImport>(false);

            // For constructor parameters they may not have an ImportAttribute
            if (imports.Length == 0)
            {
                return new ImportAttribute();
            }

            if (imports.Length == 1)
            {
                return imports[0];
            }

            // DiscoveryError (Dev10:602872): This should go through the discovery error reporting when 
            // we add a way to report discovery errors properly.
            throw ExceptionBuilder.CreateDiscoveryException(Strings.Discovery_MultipleImportAttributes, item.GetDisplayName());
        }

        // Dev10:602887 - These debug messages only exist to help mitigate and diagnosis some 
        // breaking changes and should be removed before we ship.
        [Conditional("DEBUG")]
        private static void DisplayDebugWarnings(ImportCardinality cardinality, ReflectionItem item, ImportType importType)
        {
            if ((importType.ElementType == ExportType) || (importType.Type == ExportType))
            {
                System.Diagnostics.Debug.WriteLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0} : Imports of type Export are no longer supported", item.GetDisplayName()));
            }

            // Output a debug warning if someone is using ImportAttribute where it looks like they might want to use ImportMany
            if (cardinality != ImportCardinality.ZeroOrMore && CollectionServices.GetEnumerableElementType(importType.Type) != null)
            {
                System.Diagnostics.Debug.WriteLine("May want to use ImportMany on " + item.GetDisplayName());
            }
        }

        private struct AttributedImportDefinitionCreationInfo
        {
            public string ContractName { get; set; }
            public string RequiredTypeIdentity { get; set; }
            public IEnumerable<string> RequiredMetadata { get; set; }
            public ImportCardinality Cardinality { get; set; }
            public bool IsRecomposable { get; set; }
            public CreationPolicy RequiredCreationPolicy { get; set; }
        }
    }
}
