using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_09_Task_01
{
    public class Worker : IWorker
    {
        private string name;

        public Worker(string name)
        {
            this.name = name;
        }

        public string GetWorkerName()
        {
            return this.GetType().Name + name;
        }

        public void BuildHouse(House house) {
            Console.WriteLine("Строю: {0}", house.AddNewPart());
        }
    }
}
