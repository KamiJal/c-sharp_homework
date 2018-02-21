using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_06_Task_03
{
    public class Moto : Trans
    {
        public bool hasStroller { private set; get; }

        public Moto() : this("нет данных", false) { }
        public Moto(string model, bool hasStroller) : this(model, "нет данных", 0, 0, hasStroller) { }
        public Moto(string model, string number, int speed, double carrying, bool hasStroller)
            : base(TRANS_TYPE.MOTO, model, number, speed)
        {
            this.hasStroller = hasStroller;
            this.carrying = carrying;
            
            if(!this.hasStroller)
                this.carrying = 0;
        }

        //вывод данных для пользователя
        public override string ToString()
        {
            return String.Format("{0}\nКоляска: {1}", base.ToString(), hasStroller ? "есть" : "нет");
        }
    }
}
