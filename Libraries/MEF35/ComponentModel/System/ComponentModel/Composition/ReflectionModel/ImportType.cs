// -----------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Microsoft.Internal;
using Microsoft.Internal.Collections;
using System.ComponentModel.Composition.Primitives;

namespace System.ComponentModel.Composition.ReflectionModel
{
    // Describes the import type of a Reflection-based import definition
    internal class ImportType
    {
        private readonly Type _type;
        private readonly Type _elementType;
        private readonly SpecificLazyType _lazyType;
        private readonly bool _isAssignableCollectionType;

        public ImportType(Type type, ImportCardinality cardinality)
        {
            Assumes.NotNull(type);

            this._type = type;
            this._isAssignableCollectionType = IsTypeAssignableCollectionType(type);

            if (cardinality == ImportCardinality.ZeroOrMore)
            {
                this._elementType = CollectionServices.GetEnumerableElementType(type);
            }

            this._lazyType = CreateLazyType(this._elementType ?? this._type);
        }

        public bool IsAssignableCollectionType
        {
            get { return this._isAssignableCollectionType; }
        }

        public bool IsLazy
        {
            get { return this._lazyType != null; }
        }

        public SpecificLazyType LazyType
        {
            get { return this._lazyType; }
        }

        public Type ElementType
        {
            get { return this._elementType; }
        }

        public Type Type
        {
            get { return this._type; }
        }

        public object GetStronglyTypedExport(Export exportToWrap)
        {
            Assumes.NotNull(this._lazyType);
            return this._lazyType.CreateExport(exportToWrap);
        }

        private static bool IsTypeAssignableCollectionType(Type type)
        {
            if (type.IsArray)
            {
                return true;
            }

            if (type.IsGenericType)
            {
                Type genericType = type.GetGenericTypeDefinition();

                if (genericType == typeof(IEnumerable<>))
                {
                    return true;
                }
            }

            return false;
        }

        private static SpecificLazyType CreateLazyType(Type type)
        {
            if (type.IsGenericType)
            {
                Type genericType = type.GetGenericTypeDefinition();
                Type[] arguments = type.GetGenericArguments();

                if (genericType == typeof(Lazy<>))
                {
                    return new SpecificLazyType(arguments[0], null);
                }

                if (genericType == typeof(Lazy<,>))
                {
                    return new SpecificLazyType(arguments[0], arguments[1]);
                }
            }

            return null;
        }

        internal class SpecificLazyType
        {
            public SpecificLazyType(Type elementType, Type metadataViewType)
            {
                this.ElementType = elementType ?? ExportServices.DefaultExportedValueType;
                this.MetadataViewType = metadataViewType;
                this.CreateExport = ExportServices.CreateStronglyTypedExportFactory(this.ElementType, this.MetadataViewType);
            }

            public Type ElementType { get; set; }
            public Type MetadataViewType { get; set; }
            public Func<Export, object> CreateExport { get; set; }
        }
    }
}
