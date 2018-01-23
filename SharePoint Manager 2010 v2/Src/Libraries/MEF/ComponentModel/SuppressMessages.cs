// -----------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// -----------------------------------------------------------------------
using System;
using System.Diagnostics.CodeAnalysis;

[module: SuppressMessage("Microsoft.MSInternal", "CA900:AptcaAssembliesShouldBeReviewed",
                        Justification = "Waiting for FxCop team to add our assembly to the whitelist")]


[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.Lazy`2", 
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.AttributedModelServices",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.ChangeRejectedException",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.CompositionContractMismatchException",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.CompositionError",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.CompositionException",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.CreationPolicy",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.ExportAttribute",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.ExportMetadataAttribute",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.ImportAttribute",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.ImportCardinalityMismatchException",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.ImportingConstructorAttribute",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.ImportManyAttribute",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.InheritedExportAttribute", 
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.MetadataAttributeAttribute",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.PartCreationPolicyAttribute",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.PartMetadataAttribute",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.PartNotDiscoverableAttribute",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.Hosting.AdaptingExportProvider",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.Hosting.AggregateCatalog",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.Hosting.AggregateExportProvider",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.Hosting.AssemblyCatalog",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.Hosting.CatalogExportProvider",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.Hosting.ComposablePartCatalogChangeEventArgs",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.Hosting.ComposablePartExportProvider",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.Hosting.CompositionBatch",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.Hosting.CompositionConstants",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.Hosting.CompositionContainer",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.Hosting.AtomicComposition",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.Hosting.DirectoryCatalog",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.Primitives.ExportedDelegate",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.Hosting.ExportProvider",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.Hosting.ExportsChangeEventArgs",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.Hosting.ImportEngine",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.Hosting.TypeCatalog",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.Primitives.Export",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.Primitives.ExportDefinition",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.Primitives.ComposablePart",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.Primitives.ComposablePartCatalog",
                        Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.Primitives.ComposablePartDefinition", Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.Primitives.ComposablePartException", Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.Primitives.ContractBasedImportDefinition", Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.Primitives.ImportCardinality", Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.Primitives.ImportDefinition", Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.ReflectionModel.LazyMemberInfo", Justification = "Razzle mscorlib is not APTCA")]
[module: SuppressMessage("Microsoft.Security", "CA2117:AptcaTypesShouldOnlyExtendAptcaBaseTypes", Scope = "type", Target = "System.ComponentModel.Composition.ReflectionModel.ReflectionModelServices", Justification = "Razzle mscorlib is not APTCA")]


[module: SuppressMessage("Microsoft.MSInternal", "CA905:SystemAndMicrosoftNamespacesRequireApproval", Scope = "namespace", Target = "System.ComponentModel.Composition",
                        Justification = "Approved by Framework")]

[module: SuppressMessage("Microsoft.MSInternal", "CA905:SystemNamespacesRequireApproval", Scope = "namespace", Target = "System.ComponentModel.Composition.Caching",
                        Justification = "Approved by Framework")]

[module: SuppressMessage("Microsoft.MSInternal", "CA905:SystemNamespacesRequireApproval", Scope = "namespace", Target = "System.ComponentModel.Composition.Hosting")]

[module: SuppressMessage("Microsoft.MSInternal", "CA905:SystemNamespacesRequireApproval", Scope = "namespace", Target = "System.ComponentModel.Composition.Primitives")]
[module: SuppressMessage("Microsoft.MSInternal", "CA905:SystemNamespacesRequireApproval", Scope = "namespace", Target = "System.ComponentModel.Composition.ReflectionModel")]
[module: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.ComponentModel.Composition.ReflectionModel")]
[module: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Windows")]

// BUG: DDB 90145 - GenericMethodsShouldProvideTypeParameter should ignore methods that returns T (Code Analysis bug)
[module: SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Scope = "member", Target = "System.ComponentModel.Composition.Hosting.ExportProvider.#GetExports`2(System.String)")]
[module: SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Scope = "member", Target = "System.ComponentModel.Composition.Hosting.ExportProvider.#GetExports`2(System.Linq.Expressions.Expression`1<System.Func`2<System.ComponentModel.Composition.Primitives.ExportDefinition,System.Boolean>>)")]
[module: SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Scope = "member", Target = "System.ComponentModel.Composition.Hosting.ExportProvider.#GetExports`2()")]
[module: SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Scope = "member", Target = "System.ComponentModel.Composition.Hosting.ExportProvider.#GetExports`1(System.String)")]
[module: SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Scope = "member", Target = "System.ComponentModel.Composition.Hosting.ExportProvider.#GetExports`1(System.Linq.Expressions.Expression`1<System.Func`2<System.ComponentModel.Composition.Primitives.ExportDefinition,System.Boolean>>)")]
[module: SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Scope = "member", Target = "System.ComponentModel.Composition.Hosting.ExportProvider.#GetExports`1()")]
[module: SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Scope = "member", Target = "System.ComponentModel.Composition.Hosting.ExportProvider.#GetExportedValues`1(System.String)")]
[module: SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Scope = "member", Target = "System.ComponentModel.Composition.Hosting.ExportProvider.#GetExportedValues`1()")]
[module: SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Scope = "member", Target = "System.ComponentModel.Composition.Hosting.ExportProvider.#GetExportedValueOrDefault`1(System.String)")]
[module: SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Scope = "member", Target = "System.ComponentModel.Composition.Hosting.ExportProvider.#GetExportedValueOrDefault`1()")]
[module: SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Scope = "member", Target = "System.ComponentModel.Composition.Hosting.ExportProvider.#GetExportedValue`1(System.String)")]
[module: SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Scope = "member", Target = "System.ComponentModel.Composition.Hosting.ExportProvider.#GetExportedValue`1()")]
[module: SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Scope = "member", Target = "System.ComponentModel.Composition.Hosting.ExportProvider.#GetExport`2(System.String)")]
[module: SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Scope = "member", Target = "System.ComponentModel.Composition.Hosting.ExportProvider.#GetExport`2(System.Linq.Expressions.Expression`1<System.Func`2<System.ComponentModel.Composition.Primitives.ExportDefinition,System.Boolean>>)")]
[module: SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures",  Scope = "member", Target = "System.ComponentModel.Composition.Hosting.ExportProvider.#GetExport`2(System.Linq.Expressions.Expression`1<System.Func`2<System.ComponentModel.Composition.Primitives.ExportDefinition,System.Boolean>>)")]
[module: SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Scope = "member", Target = "System.ComponentModel.Composition.Hosting.ExportProvider.#GetExport`2()")]
[module: SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Scope = "member", Target = "System.ComponentModel.Composition.Hosting.ExportProvider.#GetExport`1(System.String)")]
[module: SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Scope = "member", Target = "System.ComponentModel.Composition.Hosting.ExportProvider.#GetExport`1(System.Linq.Expressions.Expression`1<System.Func`2<System.ComponentModel.Composition.Primitives.ExportDefinition,System.Boolean>>)")]
[module: SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Scope = "member", Target = "System.ComponentModel.Composition.Hosting.ExportProvider.#GetExport`1()")]

#if SILVERLIGHT

// BUG: Dev10 - 434542 ImplementStandardExceptionConstructors fires on Silverlight exceptions even though serialization is not supported on that Framework (Code Analysis bug)
[module: SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors", Scope = "type", Target = "System.ComponentModel.Composition.CompositionException")]
[module: SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors", Scope = "type", Target = "System.ComponentModel.Composition.CardinalityMismatchException")]
[module: SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors", Scope = "type", Target = "Microsoft.Internal.Assumes+InternalErrorException")]

// Code Analysis bugs
[module: SuppressMessage("Microsoft.Usage", "CA2235:MarkAllNonSerializableFields", Scope = "member", Target = "System.ComponentModel.Composition.CompositionException.#_message")]
[module: SuppressMessage("Microsoft.Usage", "CA2235:MarkAllNonSerializableFields", Scope = "member", Target = "System.ComponentModel.Composition.ComposablePartException.#_id")]
[module: SuppressMessage("Microsoft.Design", "CA1064:ExceptionsShouldBePublic", Scope="type", Target="System.ComponentModel.Composition.ICompositionError")]
[module: SuppressMessage("Microsoft.Design", "CA1064:ExceptionsShouldBePublic", Scope="type", Target="System.ComponentModel.Composition.IAttributedImport")]
[module: SuppressMessage("Microsoft.Design", "CA1064:ExceptionsShouldBePublic", Scope="type", Target="System.ComponentModel.Composition.ReflectionModel.IReflectionPartCreationInfo")]
#endif

// All of these will go away when more types in Advanced and Primitives, and Tuple is removed from System.
[module: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System")]
[module: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Threading")]
[module: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.ComponentModel.Composition.Primitives")]

// These warnings are deliberate design decision. ICompositionElement is an advanced type and we don't want to dirty the API by make these members public
[module: SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.ComponentModel.Composition.Hosting.AssemblyCatalog.#System.ComponentModel.Composition.Primitives.ICompositionElement.DisplayName")]
[module: SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.ComponentModel.Composition.Hosting.AssemblyCatalog.#System.ComponentModel.Composition.Primitives.ICompositionElement.Origin")]
[module: SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.ComponentModel.Composition.Hosting.DirectoryCatalog.#System.ComponentModel.Composition.Primitives.ICompositionElement.DisplayName")]
[module: SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.ComponentModel.Composition.Hosting.DirectoryCatalog.#System.ComponentModel.Composition.Primitives.ICompositionElement.Origin")]
[module: SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.ComponentModel.Composition.Hosting.TypeCatalog.#System.ComponentModel.Composition.Primitives.ICompositionElement.DisplayName")]
[module: SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.ComponentModel.Composition.Hosting.TypeCatalog.#System.ComponentModel.Composition.Primitives.ICompositionElement.Origin")]
