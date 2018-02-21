using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*2.	Дан класс сожержащий внутри себя массив. 
 * Реализовать перегрузку операторов < , > так, чтобы если сумма элементов массива 1 класса больше, 
 * возвращалось значение true и наоборот.*/

namespace HomeWork_07_Task_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Test t1 = new Test(10);
            Test t2 = new Test(15);

            Console.WriteLine("t1 > t2: {0}", t1 > t2);
            Console.WriteLine("t1 < t2: {0}", t1 < t2);

            Console.ReadKey();
        }
    }
}
