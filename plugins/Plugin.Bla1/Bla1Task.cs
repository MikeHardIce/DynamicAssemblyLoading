
using System;
using SomeSharedLib;

namespace Plugin.Bla1
{
    public class Bla1Task : ITask
    {
        public void Execute()
            => Console.WriteLine("Bla1 task is executing...");
    }
}