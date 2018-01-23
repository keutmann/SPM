using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace SPM2.Framework
{
    public class AssemblyProvider
    {
        public FileInfo[] AssemblyFileInfo { get; set; }
        public List<Assembly> Assemblies { get; set; }

        private static string _assemblyPath = null;
        public static string AssemblyPath
        {
            get
            {
                if (AssemblyProvider._assemblyPath == null)
                {
                    AssemblyProvider._assemblyPath = Environment.CurrentDirectory;
                }
                return AssemblyProvider._assemblyPath; 
            }
            set { 
                AssemblyProvider._assemblyPath = value; 
            }
        }

        

        AssemblyProvider()
        {
            this.Assemblies = new List<Assembly>();
            LoadAssemblies(AssemblyProvider.AssemblyPath);
        }


        private void LoadAssemblies(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            AssemblyFileInfo = dir.GetFiles("*.dll", SearchOption.AllDirectories);

            foreach (FileInfo file in AssemblyFileInfo)
            {
               this.Assemblies.Add(Assembly.LoadFile(file.FullName));
            }
        }


        public static AssemblyProvider Current
        {
            get
            {
                return Nested._current;
            }
        }

        class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly AssemblyProvider _current = new AssemblyProvider();
        }


    }
}
