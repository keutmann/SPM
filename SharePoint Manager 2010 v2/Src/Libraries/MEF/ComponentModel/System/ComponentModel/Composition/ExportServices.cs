// -----------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// -----------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition.ReflectionModel;
using System.Reflection;
using Microsoft.Internal;
using Microsoft.Internal.Collections;
using System.Globalization;

namespace System.ComponentModel.Composition
{
    // Provides helpers for creating and dealing with Exports
    internal static partial class ExportServices
    {
        private static MethodInfo _createStronglyTypedExportOfTM = typeof(ExportServices).GetMethod("CreateStronglyTypedExportOfTM", BindingFlags.NonPublic | BindingFlags.Static);
        private static MethodInfo _createStronglyTypedExportOfT = typeof(ExportServices).GetMethod("CreateStronglyTypedExportOfT", BindingFlags.NonPublic | BindingFlags.Static);
        private static MethodInfo _createSemiStronglyTypedExport = typeof(ExportServices).GetMethod("CreateSemiStronglyTypedExport", BindingFlags.NonPublic | BindingFlags.Static);
        internal static readonly Type DefaultMetadataViewType = typeof(IDictionary<string, object>);
        internal static readonly Type DefaultExportedValueType = typeof(object);

        internal static bool IsDefaultMetadataViewType(Type metadataViewType)
        {
            Assumes.NotNull(metadataViewType);

            // Consider all types that IDictionary<string, object> derives from, such
            // as ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>> 
            // and IEnumerable, as default metadata view
            return metadataViewType.IsAssignableFrom(DefaultMetadataViewType);
        }

        internal static bool IsDictionaryConstructorViewType(Type metadataViewType)
        {
            Assumes.NotNull(metadataViewType);

            // Does the view type have a constructor that is a Dictionary<string, object>
            return metadataViewType.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                                                    Type.DefaultBinder,
                                                    new Type[] { typeof(IDictionary<string, object>) },
                                                    new ParameterModifier[0]) != null;
        }

        internal static Func<Export, object> CreateStronglyTypedExportFactory(Type exportType, Type metadataViewType)
        {
            MethodInfo genericMethod = null;
            if (metadataViewType != null)
            {
                genericMethod = _createStronglyTypedExportOfTM.MakeGenericMethod(exportType ?? ExportServices.DefaultExportedValueType, metadataViewType);
            }
            else
            {
                genericMethod = _createStronglyTypedExportOfT.MakeGenericMethod(exportType ?? ExportServices.DefaultExportedValueType);
            }
            Assumes.NotNull(genericMethod);
            return (Func<Export, object>)Delegate.CreateDelegate(typeof(Func<Export, object>), genericMethod);
        }

        internal static Func<Export, Lazy<object, object>> CreateSemiStronglyTypedExportFactory(Type exportType, Type metadataViewType)
        {
            MethodInfo genericMethod = _createSemiStronglyTypedExport.MakeGenericMethod(
                exportType ?? ExportServices.DefaultExportedValueType,
                metadataViewType ?? ExportServices.DefaultMetadataViewType);
            Assumes.NotNull(genericMethod);
            return (Func<Export, Lazy<object, object>>)Delegate.CreateDelegate(typeof(Func<Export, Lazy<object,object>>), genericMethod);
        }

        internal static Lazy<T,M> CreateStronglyTypedExportOfTM<T, M>(Export export)
        {
            IDisposable disposable = export as IDisposable;
            if (disposable != null)
            {
                return new DisposableLazy<T, M>(
                    () => ExportServices.GetExportedValueFromLazy<T>(export),
                    AttributedModelServices.GetMetadataView<M>(export.Metadata),
                    disposable);
            }
            else
            {
                return new Lazy<T, M>(
                    () => ExportServices.GetExportedValueFromLazy<T>(export),
                    AttributedModelServices.GetMetadataView<M>(export.Metadata),
                    false);
            }
        }

        internal static Lazy<T> CreateStronglyTypedExportOfT<T>(Export export)
        {
            IDisposable disposable = export as IDisposable;
            if (disposable != null)
            {
                return new DisposableLazy<T>(
                    () => ExportServices.GetExportedValueFromLazy<T>(export),
                    export as IDisposable);
            }
            else
            {
                return new Lazy<T>(() => ExportServices.GetExportedValueFromLazy<T>(export), false);

            }
        }

        internal static Lazy<object, object> CreateSemiStronglyTypedExport<T, M>(Export export)
        {
            IDisposable disposable = export as IDisposable;
            if (disposable != null)
            {
                return new DisposableLazy<object, object>(
                    () => ExportServices.GetExportedValueFromLazy<T>(export),
                    AttributedModelServices.GetMetadataView<M>(export.Metadata),
                    export as IDisposable);
            }
            else
            {
                return new Lazy<object, object>(
                    () => ExportServices.GetExportedValueFromLazy<T>(export),
                    AttributedModelServices.GetMetadataView<M>(export.Metadata),
                    false
                    );
            }
        }


        internal static T GetExportedValueFromLazy<T>(Export export)
        {
            object exportedValue = export.Value;
            object typedExportedValue = null;

            bool succeeded = ContractServices.TryCast(typeof(T), exportedValue, out typedExportedValue);
            if (!succeeded)
            {
                throw new CompositionContractMismatchException(string.Format(CultureInfo.CurrentCulture,
                    Strings.ContractMismatch_ExportedValueCannotBeCastToT,
                    export.ToElement().DisplayName,
                    typeof(T)));
            }

            return (T)typedExportedValue;
        }
        
        internal static ExportCardinalityCheckResult CheckCardinality(ImportDefinition definition, IEnumerable<Export> exports)
        {
            EnumerableCardinality actualCardinality = exports.GetCardinality();

            switch (actualCardinality)
            {
                case EnumerableCardinality.Zero:
                    if (definition.Cardinality == ImportCardinality.ExactlyOne)
                    {
                        return ExportCardinalityCheckResult.NoExports;
                    }
                    break;

                case EnumerableCardinality.TwoOrMore:
                    if (definition.Cardinality.IsAtMostOne())
                    {
                        return ExportCardinalityCheckResult.TooManyExports;
                    }
                    break;

                default:
                    Assumes.IsTrue(actualCardinality == EnumerableCardinality.One);
                    break;

            }

            return ExportCardinalityCheckResult.Match;
        }
    }
}
