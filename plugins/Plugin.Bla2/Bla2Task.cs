using System;
using SomeSharedLib;
using Plugin.Bla2.Models;
using Newtonsoft.Json;

namespace Plugin.Bla2
{
    public class Bla2Task : ITask
    {
        public void Execute()
        {
            var crazy = new Crazy 
            {
                What = " ba bu ba buhu"
            };

            string serialized = JsonConvert.SerializeObject(crazy);

            Crazy meToo = JsonConvert.DeserializeObject<Crazy>(serialized);

            meToo.Blub();

            Console.WriteLine("Bla2 task is executing...");
        } 
    }
}
