using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_05_Task_02
{
    //медведь
    public class Bear : Animal
    {
        public Bear() : this("Медведь") { }
        public Bear(string name) : this("без имени", ANIMAL_SEX.NOT_DEFINED, 0) { }
        public Bear(string name, ANIMAL_SEX sex, double price) : base("Медведь", name, sex, price) { }
    }
}
