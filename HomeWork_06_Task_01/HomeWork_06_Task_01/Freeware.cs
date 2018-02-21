using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_06_Task_01
{
    public class Freeware : Software
    {
        public Freeware(string name, string owner) : base(name, owner) { }

        //переопределение печати
        public override void Print()
        {
            Console.WriteLine("Название: {0}, производитель: {1}", this.name, this.owner);
        }

        //всегда валидна
        public override bool IsValid()
        {
            return true;
        }
    }
}
