
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace DynamicAssemblyLoader
{
    public class DynamicAssemblyTaskLoader : AssemblyLoadContext
    {
        private readonly AssemblyDependencyResolver resolver;

        private string pluginDirectory;

        private IList<string> loadedAssemblies;

        public DynamicAssemblyTaskLoader(string pluginDirectory) : base( isCollectible: true)
        {
            this.resolver = new AssemblyDependencyResolver(pluginDirectory);

            this.pluginDirectory = pluginDirectory;

            this.loadedAssemblies = new List<string>();
        }

        protected override Assembly? Load(AssemblyName assemblyName)
        {
            string assemblyPath = this.resolver.ResolveAssemblyToPath(assemblyName);

            if (!string.IsNullOrEmpty(assemblyPath))
            {
                return LoadFromAssemblyPath(assemblyPath);
            }

            return LoadAssemblyFromPluginPath(assemblyName);
        }

        private Assembly? LoadAssemblyFromPluginPath (AssemblyName assemblyName)
        {
            var references = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(m => m.Name).ToList();

            if(!references.Contains(assemblyName.Name) && !this.loadedAssemblies.Contains(assemblyName.Name) 
            && TryGetAssemblyPath(assemblyName.Name, out string path))
            {
                this.loadedAssemblies.Add(assemblyName.Name);
                return LoadFromAssemblyPath(path);
            }

            return null;
        }

        private bool TryGetAssemblyPath (string assemblyName, out string assemblyPath)
        {
            assemblyPath = "";
            foreach( var dir in Directory.GetDirectories(this.pluginDirectory))
            {
                if(Directory.GetFiles(dir).Any(m => m.EndsWith($"{assemblyName}.dll")))
                {
                    assemblyPath = Path.Combine(dir, $"{assemblyName}.dll");
                    return true;
                }
            }

            return false;
        }
    }
}