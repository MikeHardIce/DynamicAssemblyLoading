using System;
using SomeSharedLib;

namespace Plugin.Bla2
{
    public class Bla2Task : ITask
    {
        public void Execute()
            => Console.WriteLine("Bla2 task is executing...");
    }
}
