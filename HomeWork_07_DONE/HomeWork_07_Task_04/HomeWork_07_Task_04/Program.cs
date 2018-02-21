using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Необходимо реализовать второй вариант сложения денег – чтобы можно было суммировать деньги в разных валютах. 
 * Для этого создайте отдельный класс, который будет предоставлять механизм конвертации денег по заданному курсу. 
 * Кроме этого, перегрузите для класса Money оператор сравнения «==» 
 * (при перегрузке данного оператора, обязательной является и перегрузка противоположного ему оператора «!=»).
 */

namespace HomeWork_07_Task_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Money USD = new Money(MONEY_TYPE.USD, 43);
            Money KZT = new Money(MONEY_TYPE.KZT, 6500);
            Console.WriteLine("{0} KZT = {1:N2} USD", KZT.value, Converter.KZTtoUSD(KZT, 319.5392));
            Console.WriteLine("{0} USD = {1:N2} KZT", USD.value, Converter.KZTtoUSD(USD, 319.5392));

            //обновим KZT
            KZT = new Money(MONEY_TYPE.KZT, 7350);
            //переведем в доллары
            Money USDFROMKZT = new Money(MONEY_TYPE.USD, Converter.KZTtoUSD(KZT, 319.5392));
            //обратно в тенге
            Money KZTFROMUSD = new Money(MONEY_TYPE.KZT, Converter.KZTtoUSD(USDFROMKZT, 319.5392));
            //сравним первоначальный и новый
            Console.WriteLine(KZT == KZTFROMUSD);

            

            Console.ReadKey();
        }
    }
}
