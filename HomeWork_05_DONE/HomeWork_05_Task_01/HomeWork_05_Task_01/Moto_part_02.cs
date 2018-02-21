using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_05_Task_01
{
    //вторая часть класса Мoto
    public partial class Moto
    {
        //перегрузка метода ToString()
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(String.Format("Производитель: {0}, модель: {1}\n", this.maker, this.model == null ? "не задано" : this.model));
            sb.Append(String.Format("Объем: {0}, макс. скорость: {1}, л.с.: {2}\n", this.ccVolume, this.maxSpeed, this.horsePower));
            sb.Append(String.Format("Стоимость: {0} тенге\n", this.price));

            return sb.ToString();
        }
    }
}
