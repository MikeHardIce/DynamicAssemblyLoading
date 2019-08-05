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

            ITask bla1 = bla1Info.CreateTask();

            ITaskInformation bla2Info = taskLoader.LoadTaskInformation(Path.Combine(directory, "Plugin.Bla2", "Plugin.Bla2.dll"));

            ITask bla2 = bla2Info.CreateTask();


            bla2.Execute();
            bla1.Execute();
            bla2.Execute();
            bla1.Execute();
        }
    }
}
