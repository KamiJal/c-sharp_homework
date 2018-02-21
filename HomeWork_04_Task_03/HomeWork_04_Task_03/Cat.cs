using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_04_Task_03
{
    //ЗАДАЧА 2
    class Cat
    {

        public int satiety { get; set; }
        public Cat() { this.satiety = 0; }

        public void EatSomething(FOOD food)
        {
            Console.WriteLine("Мышь съела: {0}", food);
            this.satiety += (int)food;
        }
    }
}
