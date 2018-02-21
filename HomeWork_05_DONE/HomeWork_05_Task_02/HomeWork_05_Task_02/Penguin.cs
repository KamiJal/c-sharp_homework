using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_05_Task_02
{
    //пингвин
    public class Penguin : Animal
    {
        public Penguin() : this("Пингвин") { }
        public Penguin(string name) : this("без имени", ANIMAL_SEX.NOT_DEFINED, 0) { }
        public Penguin(string name, ANIMAL_SEX sex, double price) : base("Пингвин", name, sex, price) { }
    }
}
