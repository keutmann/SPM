// -----------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// -----------------------------------------------------------------------
#if SILVERLIGHT
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Microsoft.Internal;

namespace System.Windows
{
    /// <summary>
    ///     This type is dependent on the Package class, which is currently a placeholder type
    ///     added in this assembly. If the Package class does not ship with Silverlight 
    ///     then this type will also not ship. 
    /// </summary>
    public class PackageCatalog : ComposablePartCatalog, INotifyComposablePartCatalogChanged
    {
        private Lock _lock = new Lock();
        private Dictionary<Uri, Package> _packages = new Dictionary<Uri, Package>();
        private HashSet<string> _loadedAssemblies = new HashSet<string>();
        private List<ComposablePartDefinition> _parts = new List<ComposablePartDefinition>();
        private IQueryable<ComposablePartDefinition> _partsQuery;
        private volatile bool _isDisposed = false;

        public PackageCatalog()
        {
            this._partsQuery = this._parts.AsQueryable();
        }

        /// <summary>
        ///     Adds a Package to the catalog. It will ensure that the same Package added more than
        ///     once will not cause duplication in the catalog. It will also ensure that the same
        ///     assembly appearing in multiple packages will not cause duplication in the catalog.
        /// </summary>
        /// <param name="package">
        ///     Package obtained by constructing a <see cref="Package" /> object or 
        ///     calling <see cref="Package.DownloadPackageAsync" />. 
        /// </param>
        public void AddPackage(Package package)
        {
            this.ThrowIfDisposed();

            Requires.NotNull(package, "package");

            List<AssemblyCatalog> addedCatalogs = new List<AssemblyCatalog>();
            ComposablePartDefinition[] addedDefinitions;

            using (new ReadLock(this._lock))
            {
                if (this._packages.ContainsKey(package.Uri))
                {
                    // Nothing to do because the package has already been added.
                    return;
                }

                foreach (Assembly assembly in package.Assemblies)
                {
                    if (!this._loadedAssemblies.Contains(assembly.FullName))
                    {
                        addedCatalogs.Add(new AssemblyCatalog(assembly));
                    }
                }
            }

            addedDefinitions = addedCatalogs.SelectMany(asmCat => asmCat.Parts).ToArray<ComposablePartDefinition>();

            if (addedDefinitions.Length == 0)
            {
                // If the package doesn't contain any added definitions then simply add it to the 
                // list of known packages and then return
                using (new WriteLock(this._lock))
                {
                    if (!this._packages.ContainsKey(package.Uri))
                    {
                        this._packages.Add(package.Uri, package);
                    }
                }

                return;
            }

            // Need to raise the changing event inside an AtomicComposition to allow listeners
            // to contribute state change based on whether or not the changes to the catalog
            // are completed.
            using (var atomicComposition = new AtomicComposition())
            {
                var changingArgs = new ComposablePartCatalogChangeEventArgs(addedDefinitions, Enumerable.Empty<ComposablePartDefinition>(), atomicComposition);
                this.OnChanging(changingArgs); // throws ChangedRejectedException if these changes break the composition.

                using (new WriteLock(this._lock))
                {
                    if (this._packages.ContainsKey(package.Uri))
                    {
                        // Someone beat us to it so return and don't complete the AtomicComosition
                        return; 
                    }

                    this._packages.Add(package.Uri, package);

                    foreach (var catalog in addedCatalogs)
                    {
                        if (!this._loadedAssemblies.Contains(catalog.Assembly.FullName))
                        {
                            this._loadedAssemblies.Add(catalog.Assembly.FullName);
                            this._parts.AddRange(catalog.Parts);
                        }
                    }
                }

                atomicComposition.Complete();
            }

            var changedArgs = new ComposablePartCatalogChangeEventArgs(addedDefinitions, Enumerable.Empty<ComposablePartDefinition>(), null);
            this.OnChanged(changedArgs);
        }

        /// <summary>
        ///     List of packages already contained in this catalog.
        /// </summary>
        public IEnumerable<Package> Packages
        {
            get
            {
                using (new ReadLock(this._lock))
                {
                    return this._packages.Values.ToArray();
                }
            }
        }

        /// <summary>
        ///     Gets the union of all the part definitions for all the packages that have
        ///     been added to this catalog.
        /// </summary>
        /// <value>
        ///     A <see cref="IQueryable{T}"/> of <see cref="ComposablePartDefinition"/> objects of the 
        ///     <see cref="PackageCatalog"/>.
        /// </value>
        public override IQueryable<ComposablePartDefinition> Parts
        {
            get 
            {
                this.ThrowIfDisposed();

                using (new ReadLock(this._lock))
                {
                    return this._partsQuery;
                }
            }
        }

        /// <summary>
        /// Notify when the contents of the Catalog has changed.
        /// </summary>
        public event EventHandler<ComposablePartCatalogChangeEventArgs> Changed;

        /// <summary>
        /// Notify when the contents of the Catalog has changing.
        /// </summary>
        public event EventHandler<ComposablePartCatalogChangeEventArgs> Changing;

        /// <summary>
        ///     Raises the <see cref="INotifyComposablePartCatalogChanged.Changed"/> event.
        /// </summary>
        /// <param name="e">
        ///     An <see cref="ComposablePartCatalogChangeEventArgs"/> containing the data for the event.
        /// </param>
        protected virtual void OnChanged(ComposablePartCatalogChangeEventArgs e)
        {
            EventHandler<ComposablePartCatalogChangeEventArgs> changedEvent = this.Changed;
            if (changedEvent != null)
            {
                changedEvent(this, e);
            }
        }

        /// <summary>
        ///     Raises the <see cref="INotifyComposablePartCatalogChanged.Changing"/> event.
        /// </summary>
        /// <param name="e">
        ///     An <see cref="ComposablePartCatalogChangeEventArgs"/> containing the data for the event.
        /// </param>
        protected virtual void OnChanging(ComposablePartCatalogChangeEventArgs e)
        {
            EventHandler<ComposablePartCatalogChangeEventArgs> changingEvent = this.Changing;
            if (changingEvent != null)
            {
                changingEvent(this, e);
            }
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    Lock disposeLock = null;

                    if (!this._isDisposed)
                    {
                        using (new WriteLock(this._lock))
                        {
                            if (!this._isDisposed)
                            {
                                this._isDisposed = true;
                                disposeLock = this._lock;
                                this._lock = null;
                                this._packages = null;
                                this._loadedAssemblies = null;
                                this._parts = null;
                                this._partsQuery = null;
                            }
                        }
                    }

                    if (disposeLock != null)
                    {
                        disposeLock.Dispose();
                    }
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        private void ThrowIfDisposed()
        {
            if (this._isDisposed)
            {
                throw ExceptionBuilder.CreateObjectDisposed(this);
            }
        }
    }
}
#endif