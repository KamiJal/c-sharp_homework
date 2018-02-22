using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_09_Task_01
{
    public class Window : IPart
    {
        public string GetPartName()
        {
            return this.GetType().Name;
        }
    }
}
