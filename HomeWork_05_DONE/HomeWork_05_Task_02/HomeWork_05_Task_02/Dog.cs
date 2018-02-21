using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_05_Task_02
{
    //собака
    public class Dog : Animal
    {
        public Dog() : this("Собака") { }
        public Dog(string name) : this("без имени", ANIMAL_SEX.NOT_DEFINED, 0) { }
        public Dog(string name, ANIMAL_SEX sex, double price) : base("Собака", name, sex, price) { }
    }
}
