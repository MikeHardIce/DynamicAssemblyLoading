using System;

namespace SomeSharedLib
{
    public interface ITaskInformation
    {
        string Name { get; }

        

        ITask CreateTask ();
    }
}
