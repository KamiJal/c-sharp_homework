using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_06_Task_03
{
    public class Truck : Trans
    {
        public bool hasTrailer { private set; get; }

        public Truck() : this("нет данных", false) { }
        public Truck(string model, bool hasTrailer) : this(model, "нет данных", 0, 0, hasTrailer) { }
        public Truck(string model, string number, int speed, double carrying, bool hasTrailer)
            : base(TRANS_TYPE.TRUCK, model, number, speed)
        {
            this.hasTrailer = hasTrailer;
            this.carrying = carrying;

            if (this.hasTrailer)
                this.carrying *= 2;
        }

        //вывод данных для пользователя
        public override string ToString()
        {
            return String.Format("{0}\nПрицеп: {1}", base.ToString(), hasTrailer ? "есть" : "нет");
        }
    }
}
