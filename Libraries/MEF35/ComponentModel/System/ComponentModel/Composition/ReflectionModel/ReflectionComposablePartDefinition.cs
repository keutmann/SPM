// -----------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System.Threading;
using Microsoft.Internal;

namespace System.ComponentModel.Composition.ReflectionModel
{
    internal class ReflectionComposablePartDefinition : ComposablePartDefinition, ICompositionElement
    {
        private readonly IReflectionPartCreationInfo _creationInfo;

        private IEnumerable<ImportDefinition> _imports;
        private IEnumerable<ExportDefinition> _exports;
        private IDictionary<string, object> _metadata;
        private ConstructorInfo _constructor;

        public ReflectionComposablePartDefinition(IReflectionPartCreationInfo creationInfo)
        {
            Assumes.NotNull(creationInfo);
            this._creationInfo = creationInfo;
        }

        public Type GetPartType()
        {
            return this._creationInfo.GetPartType();
        }

        public Lazy<Type> GetLazyPartType()
        {
            return this._creationInfo.GetLazyPartType();
        }

        public ConstructorInfo GetConstructor()
        {
            if (this._constructor == null)
            {
                this._constructor = this._creationInfo.GetConstructor();
            }

            return this._constructor;
        }

        public override IEnumerable<ExportDefinition> ExportDefinitions
        {
            get
            {
                if (this._exports == null)
                {
                    this._exports = this._creationInfo.GetExports().ToArray();
                }
                return this._exports;
            }
        }

        public override IEnumerable<ImportDefinition> ImportDefinitions
        {
            get
            {
                if (this._imports == null)
                {
                    this._imports = this._creationInfo.GetImports().ToArray();
                }
                return this._imports;
            }
        }

        public override IDictionary<string, object> Metadata
        {
            get
            {
                if (this._metadata == null)
                {
                    this._metadata = this._creationInfo.GetMetadata().AsReadOnly();
                }
                return this._metadata;
            }
        }

        internal bool IsDisposalRequired
        {
            get
            {
                return this._creationInfo.IsDisposalRequired;
            }
        }

        public override ComposablePart CreatePart()
        {
            if (this.IsDisposalRequired)
            {
                return new DisposableReflectionComposablePart(this);
            }
            else
            {
                return new ReflectionComposablePart(this);
            }
        }

        string ICompositionElement.DisplayName
        {
            get { return this._creationInfo.DisplayName; }
        }

        ICompositionElement ICompositionElement.Origin
        {
            get { return this._creationInfo.Origin; }
        }

        public override string ToString()
        {
            return this._creationInfo.DisplayName;
        }
    }
}
