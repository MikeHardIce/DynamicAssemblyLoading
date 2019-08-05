
using System.Reflection;
using System.Runtime.Loader;

namespace DynamicAssemblyLoader
{
    public class DynamicAssemblyTaskLoader : AssemblyLoadContext
    {
        private readonly AssemblyDependencyResolver resolver;
        public DynamicAssemblyTaskLoader(string pluginDirectory) : base( isCollectible: true)
        {
            this.resolver = new AssemblyDependencyResolver(pluginDirectory);
        }

        protected override Assembly? Load(AssemblyName assemblyName)
        {
            string assemblyPath = this.resolver.ResolveAssemblyToPath(assemblyName);

            if (!string.IsNullOrEmpty(assemblyPath))
            {
                return LoadFromAssemblyPath(assemblyPath);
            }

            return null;
        }
    }
}