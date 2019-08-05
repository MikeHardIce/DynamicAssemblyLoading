using System;
using System.IO;
using SomeSharedLib;

namespace DynamicAssemblyLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = Path.Combine(Directory.GetCurrentDirectory(), "plugins");

            var assemblyLoader = new DynamicAssemblyTaskLoader(directory);

            var taskLoader = new DynamicTaskLoader(assemblyLoader);

            ITaskInformation bla1Info = taskLoader.LoadTaskInformation(Path.Combine(directory, "Plugin.Bla1", "Plugin.Bla1.dll"));

            bla1Info.CreateTask().Execute();

            ITaskInformation bla2Info = taskLoader.LoadTaskInformation(Path.Combine(directory, "Plugin.Bla2", "Plugin.Bla2.dll"));

            bla2Info.CreateTask().Execute();
        }
    }
}
