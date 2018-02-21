using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_06_Task_01
{
    public class Shareware : Software
    {
        protected DateTime installDate { private set; get; }    //дата установки
        protected int usingPeriod { private set; get; }         //период использования

        public Shareware(string name, string owner, DateTime installDate, int usingPeriod)
            : base(name, owner)
        {
            this.installDate = installDate;
            this.usingPeriod = usingPeriod;
        }

        //переопределение печати
        public override void Print()
        {
            Console.WriteLine("Название: {0}, производитель: {1}, дата установки: {2}, пробный период: {3} (в днях)", this.name, this.owner, this.installDate.ToString("dd.MM.yyyy"), usingPeriod);
            Console.WriteLine("Возможность использования на текущую дату: {0}", this.IsValid() ? "возможно" : "невозможно");
        }

        //отнимаем от текущей даты дату установки и считаем количество пройденных дней - сверяем с периодом использования
        public override bool IsValid()
        {
            return (int)(DateTime.Now - installDate).TotalDays <= usingPeriod;
        }
    }
}
