using System;
using SomeSharedLib;

namespace Plugin.Bla1
{
    public class Bla1TaskInformation : ITaskInformation
    {
        public string Name => "Bla1";
        
        public ITask CreateTask()
            => new Bla1Task();
    }
}
