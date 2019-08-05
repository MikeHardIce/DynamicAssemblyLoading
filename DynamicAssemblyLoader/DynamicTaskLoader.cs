
using System.Linq;
using System.Reflection;
using SomeSharedLib;

namespace DynamicAssemblyLoader
{
    public class DynamicTaskLoader
    {
        private DynamicAssemblyTaskLoader assemblyTaskLoader;
        public DynamicTaskLoader(DynamicAssemblyTaskLoader loader)
        {
            this.assemblyTaskLoader = loader;
        }

        public ITaskInformation LoadTaskInformation (string pluginPath)
        {
            Assembly plugin = this.assemblyTaskLoader.LoadFromAssemblyPath(pluginPath);

            var typeOfPluggedTaskInformation = plugin.DefinedTypes.FirstOrDefault(m => m.ImplementedInterfaces.Any( t => t.FullName == typeof(ITaskInformation).FullName));

            var taskInfo = plugin.CreateInstance(typeOfPluggedTaskInformation.Name) as ITaskInformation;

            return taskInfo;
        }
    }
}