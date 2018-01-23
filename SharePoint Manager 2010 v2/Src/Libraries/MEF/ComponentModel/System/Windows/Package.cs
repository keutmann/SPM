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
using System.Windows.Resources;
using Microsoft.Internal;
using System.Net;
using System.IO;
using System.Xml;
using System.ComponentModel;

namespace System.Windows
{
    /// <summary>
    ///     This is a prototype API that we have proposed to the Silverlight team to represent a Package (aka XAP)
    ///     so that we can get work on some Catalogs that specifically target Silverlight packages. It is only here 
    ///     as a placeholder and will not ship as part of System.ComponentModel.Composition.dll. If Silverlight doesn't
    ///     add this or a similar API then any of the Catalogs we create that target packages will not ship with Silverlight.
    /// </summary>
    public class Package
    {
        public Package(Uri packageUri, IEnumerable<Assembly> assemblies)
        {
            this.Uri = packageUri;
            this.Assemblies = assemblies;
        }

        public Uri Uri { get; private set; }

        public IEnumerable<Assembly> Assemblies { get; private set; }

        private static Package _current;
        public static Package Current
        {
            get
            {
                if (_current == null)
                {
                    var assemblies = new List<Assembly>();

                    foreach (AssemblyPart ap in Deployment.Current.Parts)
                    {
                        StreamResourceInfo sri = Application.GetResourceStream(new Uri(ap.Source, UriKind.Relative));
                        if (sri != null)
                        {
                            Assembly assembly = new AssemblyPart().Load(sri.Stream);
                            assemblies.Add(assembly);
                        }
                    }

                    _current = new Package(new Uri("", UriKind.Relative), assemblies);
                }

                return _current;
            }
        }

        public static void DownloadPackageAsync(Uri packageUri, Action<AsyncCompletedEventArgs, Package> packageDownloadCompleted)
        {
            var client = new WebClient();

            client.OpenReadCompleted += new OpenReadCompletedEventHandler(client_OpenReadCompleted);

            client.OpenReadAsync(packageUri, new Tuple<Uri, Action<AsyncCompletedEventArgs, Package>>(packageUri, packageDownloadCompleted));
        }

        private static void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            var tuple = (Tuple<Uri, Action<AsyncCompletedEventArgs, Package>>)e.UserState;

            var uri = tuple.Item1;
            var callback = tuple.Item2;

            Package package = null;

            if (e.Error == null && !e.Cancelled)
            {
                IEnumerable<Assembly> assemblies = LoadPackagedAssemblies(e.Result);
                package = new Package(uri, assemblies);
            }

            callback(new AsyncCompletedEventArgs(e.Error, e.Cancelled, null), package);
        }
      
        private static IEnumerable<Assembly> LoadPackagedAssemblies(Stream packageStream)
        {
            List<Assembly> assemblies = new List<Assembly>();
            StreamResourceInfo packageStreamInfo = new StreamResourceInfo(packageStream, null);

            IEnumerable<AssemblyPart> parts = GetDeploymentParts(packageStreamInfo);

            foreach (AssemblyPart ap in parts)
            {
                StreamResourceInfo sri = Application.GetResourceStream(
                    packageStreamInfo, new Uri(ap.Source, UriKind.Relative));

                //TODO: This has not been tested with SL3 Transparent parts and
                // will likely cause a failure because they aren't actually
                // packed in the package as a stream. 
                assemblies.Add(ap.Load(sri.Stream));
            }
            return assemblies;
        }

        private static IEnumerable<AssemblyPart> GetDeploymentParts(StreamResourceInfo xapStreamInfo)
        {
            Uri manifestUri = new Uri("AppManifest.xaml", UriKind.Relative);
            StreamResourceInfo manifestStreamInfo = Application.GetResourceStream(
                xapStreamInfo, manifestUri);
            Stream manifestStream = manifestStreamInfo.Stream;

            List<AssemblyPart> assemblyParts = new List<AssemblyPart>();
            using (XmlReader reader = XmlReader.Create(manifestStream))
            {
                if (reader.ReadToFollowing("AssemblyPart"))
                {
                    do
                    {
                        string source = reader.GetAttribute("Source");

                        if (source != null)
                        {
                            assemblyParts.Add(new AssemblyPart() { Source = source });
                        }
                    }
                    while (reader.ReadToNextSibling("AssemblyPart"));
                }
            }

            return assemblyParts;
        }
    }
}
#endif