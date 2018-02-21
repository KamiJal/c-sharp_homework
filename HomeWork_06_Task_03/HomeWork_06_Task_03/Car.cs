using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_06_Task_03
{
    public class Car : Trans
    {
        public Car() : this("нет данных") { }
        public Car(string model) : this(model, "нет данных", 0, 0) { }
        public Car(string model, string number, int speed, double carrying) : base(TRANS_TYPE.CAR, model, number, speed) { this.carrying = carrying; }
    }
}
