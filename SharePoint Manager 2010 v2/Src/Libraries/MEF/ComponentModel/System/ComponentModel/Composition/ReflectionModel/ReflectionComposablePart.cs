
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
    internal class ReflectionComposablePart : ComposablePart, ICompositionElement
    {
        private readonly ReflectionComposablePartDefinition _definition;
        private readonly Dictionary<ImportDefinition, object> _importValues = new Dictionary<ImportDefinition, object>();
        private readonly Dictionary<ImportDefinition, ImportingItem> _importsCache = new Dictionary<ImportDefinition, ImportingItem>();
        private readonly Dictionary<ExportDefinition, ExportingMember> _exportsCache = new Dictionary<ExportDefinition, ExportingMember>();
        private bool _invokeImportsSatisfied = true;
        private bool _invokingImportsSatisfied = false;
        private bool _initialCompositionComplete = false;
        private object _cachedInstance;

        public ReflectionComposablePart(ReflectionComposablePartDefinition definition)
        {
            Requires.NotNull(definition, "definition");

            this._definition = definition;
        }

        public ReflectionComposablePart(ReflectionComposablePartDefinition definition, object attributedPart)
        {
            Requires.NotNull(definition, "definition");
            Requires.NotNull(attributedPart, "attributedPart");

            this._definition = definition;

            if (attributedPart is ValueType)
            {
                throw new ArgumentException(Strings.ArgumentValueType, "attributedPart");
            }
            this._cachedInstance = attributedPart;
        }

        protected virtual void EnsureRunning()
        {
        }

        protected object CachedInstance
        {
            get
            {
                return this._cachedInstance;
            }
        }

        public ReflectionComposablePartDefinition Definition
        {
            get 
            {
                this.EnsureRunning();
                return this._definition; 
            }
        }

        public override IDictionary<string, object> Metadata
        {
            get
            {
                this.EnsureRunning();
                return this.Definition.Metadata;
            }
        }

        public sealed override IEnumerable<ImportDefinition> ImportDefinitions
        {
            get
            {
                this.EnsureRunning();
                return this.Definition.ImportDefinitions;
            }
        }

        public sealed override IEnumerable<ExportDefinition> ExportDefinitions
        {
            get
            {
                this.EnsureRunning();
                return this.Definition.ExportDefinitions;
            }
        }


        string ICompositionElement.DisplayName
        {
            get { return GetDisplayName(); }
        }

        ICompositionElement ICompositionElement.Origin
        {
            get { return Definition; }
        }

        public override object GetExportedValue(ExportDefinition definition)
        {
            this.EnsureRunning();

            Requires.NotNull(definition, "definition");

            ExportingMember member = GetExportingMemberFromDefinition(definition);
            if (member == null)
            {
                throw ExceptionBuilder.CreateExportDefinitionNotOnThisComposablePart("definition");
            }

            this.EnsureGettable();

            return this.GetExportedValue(member);
        }

        public override void SetImport(ImportDefinition definition, IEnumerable<Export> exports)
        {
            this.EnsureRunning();

            Requires.NotNull(definition, "definition");
            Requires.NotNull(exports, "exports");

            ImportingItem item = GetImportingItemFromDefinition(definition);
            if (item == null)
            {
                throw ExceptionBuilder.CreateImportDefinitionNotOnThisComposablePart("definition");
            }

            EnsureSettable(definition);

            // Avoid walking over exports many times
            Export[] exportsAsArray = exports.AsArray();
            EnsureCardinality(definition, exportsAsArray);

            SetImport(item, exportsAsArray);
        }

        public override void OnComposed()
        {
            this.EnsureRunning();

            this.SetNonPrerequisiteImports();

            // Whenever we are composed/recomposed notify the instance
            this.NotifyImportSatisfied();

            this._initialCompositionComplete = true;
        }

        public override string ToString()
        {
            return this.GetDisplayName();
        }

        private object GetExportedValue(ExportingMember member)
        {
            object instance = null;
            if (member.RequiresInstance)
            {   // Only activate the instance if we actually need to

                instance = this.GetInstanceActivatingIfNeeded();
            }

            return member.GetExportedValue(instance);
        }

        private void SetImport(ImportingItem item, Export[] exports)
        {
            object value = item.CastExportsToImportType(exports);

            this._invokeImportsSatisfied = true;
            this._importValues[item.Definition] = value;
        }

        private object GetInstanceActivatingIfNeeded()
        {
            if (this._cachedInstance == null && this.RequiresActivation())
            {
                ConstructorInfo constructor = this.Definition.GetConstructor();
                if (constructor == null)
                {
                    throw new ComposablePartException(
                        CompositionErrorId.ReflectionModel_PartConstructorMissing,
                        String.Format(CultureInfo.CurrentCulture,
                            Strings.ReflectionModel_PartConstructorMissing,
                            this.Definition.GetPartType().FullName),
                        this.Definition.ToElement());
                }
                else
                {
                    this._cachedInstance = this.CreateInstance(constructor, this.GetConstructorArguments());
                }
            }
            return this._cachedInstance;
        }

        private object[] GetConstructorArguments()
        {
            ReflectionParameterImportDefinition[] parameterImports = this.ImportDefinitions.OfType<ReflectionParameterImportDefinition>().ToArray();
            object[] arguments = new object[parameterImports.Length];

            this.UseImportedValues(
                parameterImports,
                (import, definition, value) =>
                {
                    if (definition.Cardinality == ImportCardinality.ZeroOrMore && !import.ImportType.IsAssignableCollectionType)
                    {
                        throw new ComposablePartException(
                            CompositionErrorId.ReflectionModel_ImportManyOnParameterCanOnlyBeAssigned,
                            String.Format(CultureInfo.CurrentCulture,
                                Strings.ReflectionModel_ImportManyOnParameterCanOnlyBeAssigned,
                                this.Definition.GetPartType().FullName,
                                definition.ImportingLazyParameter.Value.Name),
                            this.Definition.ToElement());
                    }

                    arguments[definition.ImportingLazyParameter.Value.Position] = value;
                },
                true);

            return arguments;
        }

        private bool RequiresActivation()
        {
            // If we have any imports then we need activation
            // (static imports are not supported)
            if (this.ImportDefinitions.Any())
            {
                return true;
            }

            // If we have any instance exports, then we also 
            // need activation.
            return this.ExportDefinitions.Any(definition =>
            {
                ExportingMember member = GetExportingMemberFromDefinition(definition);

                return member.RequiresInstance;
            });
        }

        private void EnsureGettable()
        {
            // If we're already composed then we know that 
            // all pre-req imports have been satisfied
            if (_initialCompositionComplete)
            {
                return;
            }

            // Make sure all pre-req imports have been set
            foreach (ImportDefinition definition in ImportDefinitions.Where(definition => definition.IsPrerequisite))
            {
                if (!this._importValues.ContainsKey(definition))
                {
                    throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture,
                                                            Strings.InvalidOperation_GetExportedValueBeforePrereqImportSet,
                                                            definition.ToElement().DisplayName));
                }
            }
        }

        private void EnsureSettable(ImportDefinition definition)
        {
            if (_initialCompositionComplete && !definition.IsRecomposable)
            {
                throw new InvalidOperationException(Strings.InvalidOperation_DefinitionCannotBeRecomposed);
            }
        }

        private static void EnsureCardinality(ImportDefinition definition, Export[] exports)
        {
            Requires.NullOrNotNullElements(exports, "exports");

            ExportCardinalityCheckResult result = ExportServices.CheckCardinality(definition, exports);

            switch (result)
            {
                case ExportCardinalityCheckResult.NoExports:
                    throw new ArgumentException(Strings.Argument_ExportsEmpty, "exports");

                case ExportCardinalityCheckResult.TooManyExports:
                    throw new ArgumentException(Strings.Argument_ExportsTooMany, "exports");

                default:
                    Assumes.IsTrue(result == ExportCardinalityCheckResult.Match);
                    break;
            }
        }

        private object CreateInstance(ConstructorInfo constructor, object[] arguments)
        { 
            Exception exception = null;
            object instance = null;

            try
            {
                instance = constructor.Invoke(arguments);
            }
            catch (TypeInitializationException ex) 
            { 
                exception = ex; 
            }
            catch (TargetInvocationException ex)
            {
                exception = ex.InnerException;
            }
            
            if (exception != null)
            {
                throw new ComposablePartException(
                    CompositionErrorId.ReflectionModel_PartConstructorThrewException,
                    String.Format(CultureInfo.CurrentCulture,
                        Strings.ReflectionModel_PartConstructorThrewException,
                        Definition.GetPartType().FullName),
                    Definition.ToElement(),
                    exception);
            }

            return instance;
        }

        private void SetNonPrerequisiteImports()
        {
            IEnumerable<ImportDefinition> members = this.ImportDefinitions.Where(import => !import.IsPrerequisite);

            // NOTE: Dev10 484204 The validation is turned off for post imports because of it broke declarative composition
            this.UseImportedValues(members, SetExportedValueForImport, false);
        }

        private void SetExportedValueForImport(ImportingItem import, ImportDefinition definition, object value)
        {
            ImportingMember importMember = (ImportingMember)import;

            object instance = this.GetInstanceActivatingIfNeeded();

            importMember.SetExportedValue(instance, value);
        }

        private void UseImportedValues<TImportDefinition>(IEnumerable<TImportDefinition> definitions, Action<ImportingItem, TImportDefinition, object> useImportValue, bool errorIfMissing)
            where TImportDefinition : ImportDefinition
        {
            var result = CompositionResult.SucceededResult;

            foreach (var definition in definitions)
            {
                ImportingItem import = GetImportingItemFromDefinition(definition);

                object value;
                if (!TryGetImportValue(definition, out value))
                {
                    if (!errorIfMissing)
                    {
                        continue;
                    }

                    if (definition.Cardinality == ImportCardinality.ExactlyOne)
                    {
                        var error = CompositionError.Create(
                            CompositionErrorId.ImportNotSetOnPart,
                            Strings.ImportNotSetOnPart,
                            this.Definition.GetPartType().FullName,
                            definition.ToString());
                        result = result.MergeError(error);
                        continue;
                    }
                    else
                    {
                        value = import.CastExportsToImportType(new Export[0]);
                    }
                }

                useImportValue(import, definition, value);
            }

            result.ThrowOnErrors();
        }

        private bool TryGetImportValue(ImportDefinition definition, out object value)
        {
            if (this._importValues.TryGetValue(definition, out value))
            {
                this._importValues.Remove(definition);
                return true;
            }

            value = null;
            return false;
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        private void NotifyImportSatisfied()
        {
            if (this._invokeImportsSatisfied && !this._invokingImportsSatisfied)
            {
                IPartImportsSatisfiedNotification notify = this.GetInstanceActivatingIfNeeded() as IPartImportsSatisfiedNotification;
                if (notify != null)
                {
                    try
                    {
                        // Reentrancy on composition notifications is allowed, so set this first to avoid 
                        // an infinte loop of notifications.
                        this._invokingImportsSatisfied = true;

                        notify.OnImportsSatisfied();
                    }
                    catch (Exception exception)
                    {
                        throw new ComposablePartException(
                            CompositionErrorId.ReflectionModel_PartOnImportsSatisfiedThrewException,
                            String.Format(CultureInfo.CurrentCulture,
                                Strings.ReflectionModel_PartOnImportsSatisfiedThrewException,
                                Definition.GetPartType().FullName),
                            Definition.ToElement(),
                            exception);
                    }
                    finally
                    {
                        this._invokingImportsSatisfied = false;
                    }

                    this._invokeImportsSatisfied = false;
                }
            }
        }

        private ExportingMember GetExportingMemberFromDefinition(ExportDefinition definition)
        {
            ExportingMember result;
            if (!_exportsCache.TryGetValue(definition, out result))
            {
                result = GetExportingMember(definition);
                if (result != null)
                {
                    _exportsCache[definition] = result;
                }
            }

            return result;
        }

        private ImportingItem GetImportingItemFromDefinition(ImportDefinition definition)
        {
            ImportingItem result;
            if (!_importsCache.TryGetValue(definition, out result))
            {
                result = GetImportingItem(definition);
                if (result != null)
                {
                    _importsCache[definition] = result;
                }
            }

            return result;
        }

        private static ImportingItem GetImportingItem(ImportDefinition definition)
        {
            ReflectionImportDefinition reflectionDefinition = definition as ReflectionImportDefinition;
            if (reflectionDefinition != null)
            {
                return reflectionDefinition.ToImportingItem();
            }

            // Don't recognize it
            return null;
        }

        private static ExportingMember GetExportingMember(ExportDefinition definition)
        {
            ReflectionMemberExportDefinition exportDefinition = definition as ReflectionMemberExportDefinition;
            if (exportDefinition != null)
            {
                return exportDefinition.ToExportingMember();
            }

            // Don't recognize it
            return null;
        }

        private string GetDisplayName()
        {
            return this.Definition.GetPartType().GetDisplayName();
        }
    }
}