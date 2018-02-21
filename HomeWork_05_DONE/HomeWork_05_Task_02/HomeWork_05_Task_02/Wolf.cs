using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_05_Task_02
{
    //волк
    public class Wolf : Animal
    {       
        public Wolf() : this("Волк") { }
        public Wolf(string name) : this("без имени", ANIMAL_SEX.NOT_DEFINED, 0) { }
        public Wolf(string name, ANIMAL_SEX sex, double price) : base("Волк", name, sex, price) { }
    }
}
