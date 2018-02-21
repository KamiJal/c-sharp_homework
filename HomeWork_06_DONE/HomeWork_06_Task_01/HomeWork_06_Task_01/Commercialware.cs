using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_06_Task_01
{
    public class Commercialware : Shareware
    {
        public double price {private set; get;}     //стоимость программы

        public Commercialware(string name, string owner, DateTime installDate, int usingPeriod, double price)
            : base(name, owner, installDate, usingPeriod)
        {
            this.price = price;
        }

        //переопределение печати
        public override void Print()
        {
            Console.WriteLine("Название: {0}, производитель: {1}, цена: {2}, дата установки: {3}, срок пользования: {4} (в днях)", 
                this.name, this.owner, price, this.installDate.ToString("dd.MM.yyyy"), usingPeriod);
            Console.WriteLine("Возможность использования на текущую дату: {0}", this.IsValid() ? "возможно" : "невозможно");
        }
    }
}
