using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_09_Task_01
{
    public interface IWorker
    {
        void BuildHouse(House house);
        string GetWorkerName();
    }
}
