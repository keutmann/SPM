// -----------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.Internal;
using Microsoft.Internal.Collections;
using System.Threading;

namespace System.ComponentModel.Composition.Hosting
{
    public static class CompositionConstants
    {
        private const string CompositionNamespace = "System.ComponentModel.Composition";

        public const string PartCreationPolicyMetadataName = CompositionNamespace + ".CreationPolicy";
        public const string ExportTypeIdentityMetadataName = "ExportTypeIdentity";
    }
}
