using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using System.Reflection;
using System.IO;

namespace SPM2.Framework.IoC
{
    public class AutoLoadAssemblies : Autofac.Module
    {

        public IEnumerable<Assembly> Assemblies { get; set; }

        public AutoLoadAssemblies()
        {
            // Auto find all assemblies
            Assemblies = FindAssemblies("addin");
        }


        public AutoLoadAssemblies(IEnumerable<Assembly> assemblies)
        {
            Assemblies = assemblies;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.Register(c => new AutofacIocAdapter(c.Resolve<IComponentContext>())).As<IContainerAdapter>();

            foreach (var assembly in Assemblies)
            {
                var types = assembly.GetTypes();

                foreach (var t in types)
                {
                    //Console.WriteLine("Trying Type: " + t.Name);

                    if (!t.IsClass ||
                        t.IsAbstract ||
                        t.IsGenericTypeDefinition ||
                        t.IsDelegate() ||
                        t.HasIoCIgnore())
                        continue;


                    builder.RegisterType(t).AsSelf().AsImplementedInterfaces().IoC();

#if DEBUG
                    Console.WriteLine("Type: " + t.Name);
#endif
                }

            }
        }


        private IEnumerable<Assembly> FindAssemblies(string addinPath)
        {
            //A catalog that can aggregate other catalogs
            //var aggrCatalog = new AggregateCatalog();

            //An assembly catalog
            //var currentAssemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            //aggrCatalog.Catalogs.Add(currentAssemblyCatalog);
            
            var list = new List<Assembly>();
            //var executionAssembly = Assembly.GetExecutingAssembly();
            string assmPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var dir = new DirectoryInfo(assmPath);

            foreach (var item in dir.GetFiles("*.dll"))
	        {
                if (IsExcluded(item))
                    continue;

                list.Add(Assembly.LoadFile(item.FullName));
		 
	        }

            foreach (var item in dir.GetFiles("*.exe"))
	        {
                list.Add(Assembly.LoadFile(item.FullName));
		 
	        }
            //dir.GetFiles(
            //executionAssembly.CodeBase

            ////var dirCatalog = new DirectoryCatalog(assmPath + "\\" + addinPath, "*.dll");

            //aggrCatalog.Catalogs.Add(new DirectoryCatalog(assmPath, "*.dll"));
            //aggrCatalog.Catalogs.Add(new DirectoryCatalog(assmPath, "*.exe"));

            //Create a container
            return list;
        }

        private bool IsExcluded(FileInfo file)
        {
            return "AutoFac.dll".StartsWith(file.Name, StringComparison.OrdinalIgnoreCase);


        }

    }
}

