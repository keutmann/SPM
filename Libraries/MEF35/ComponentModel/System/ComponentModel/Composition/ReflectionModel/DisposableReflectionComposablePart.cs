
// -----------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Microsoft.Internal;
using Microsoft.Internal.Collections;

namespace System.ComponentModel.Composition.ReflectionModel
{
    internal sealed class DisposableReflectionComposablePart : ReflectionComposablePart, IDisposable
    {
        private bool _isDisposed = false;

        public DisposableReflectionComposablePart(ReflectionComposablePartDefinition definition)
            : base(definition)
        {
        }

        protected override void EnsureRunning()
        {
            base.EnsureRunning();
            if (this._isDisposed)
            {
                throw ExceptionBuilder.CreateObjectDisposed(this);
            }
        }

        void IDisposable.Dispose()
        {
            if (!this._isDisposed)
            {
                IDisposable disposable = this.CachedInstance as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
                this._isDisposed = true;
            }
        }
    }
}
