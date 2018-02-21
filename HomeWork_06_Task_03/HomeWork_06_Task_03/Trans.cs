using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_06_Task_03
{
    public abstract class Trans
    {
        public TRANS_TYPE type { private set; get; }
        public string model { private set; get; }
        public string number { private set; get; }
        public int speed { private set; get; }
        public double carrying { protected set; get; }

        protected Trans(TRANS_TYPE type, string model, string number, int speed)
        {
            this.type = type;
            this.model = model;
            this.number = number;
            this.speed = speed;
        }

        //вывод данных для пользователя
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string typeDescr = "нет данных";
            switch (type)
            {
                case TRANS_TYPE.MOTO: typeDescr = "МОТОЦИКЛ"; break;
                case TRANS_TYPE.CAR: typeDescr = "ЛЕГКОВАЯ МАШИНА"; break;
                case TRANS_TYPE.TRUCK: typeDescr = "ГРУЗОВИК"; break;
            }

            sb.Append(String.Format("ТИП: {0}\n", typeDescr));
            sb.Append(String.Format("Модель: {0}, номер: {1}\nМаксимальная скорость: {2} км/ч, грузоподъемность: {3} кг.", this.model, this.number, this.speed, this.carrying));

            return sb.ToString();
        }
    }
}
