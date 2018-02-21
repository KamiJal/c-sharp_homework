using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 1.	Создать класс с несколькими свойствами. Реализовать перегрузку операторов ==, != и Equals.
 */

namespace HomeWork_07_Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Monitor lg = new Monitor("LG", "IPS231", 23.8, 60000);
            Monitor samsung = new Monitor("Samsung", "SM238", 24, 53000);
            Monitor lgNewSimilar = new Monitor("LG", "IPS231", 23.8, 60000);
            Monitor lgCopy = lg;

            //диагонали не равны, поэтому false
            Console.WriteLine(lg == samsung);                       //false
            //диагонали равны, поэтму false
            Console.WriteLine(lg != lgNewSimilar);                  //false
            //данные полностью соответствуют, но это не один и тот же объект
            Console.WriteLine(lg.Equals(lgNewSimilar));             //false
            //данные соответствуют, как и все ссылки
            Console.WriteLine(lg.Equals(lgCopy));                   //true

            Console.ReadKey();
        }
    }
}
