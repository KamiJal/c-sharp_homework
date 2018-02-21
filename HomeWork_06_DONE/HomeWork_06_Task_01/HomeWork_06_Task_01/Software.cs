using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_06_Task_01
{
    public abstract class Software
    {
        protected string name { get; private set; }     //название
        protected string owner { get; private set; }    //производитель

        protected Software(string name, string owner)
        {
            this.name = name;
            this.owner = owner;
        }

        //печатает данные о программе
        public abstract void Print();

        //проверяет на валидность относительно срока использования
        public abstract bool IsValid();
    }
}
