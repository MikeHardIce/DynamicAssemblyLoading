
using SomeSharedLib;

namespace Plugin.Bla2
{
    public class Bla2TaskInformation : ITaskInformation
    {
        public string Name => "Bla2";

        public ITask CreateTask()
            => new Bla2Task();
    }
}