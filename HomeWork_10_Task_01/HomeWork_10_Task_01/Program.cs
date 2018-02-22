using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*1.	Перехватить исключение запроса к несуществующему веб ресурсу и вывести сообщение о том, что произошла ошибка. Программа должна завершиться без ошибок.
2.	Написать программу, которая обращается к элементам массива по индексу и выходит за его пределы. После обработки исключения вывести в финальном блоке сообщение о завершении обработки массива.
3.	Реализовать несколько методов или классов с методами и вызвать один метод из другого. В вызываемом методе сгенерировать исключение и «поднять» его в вызывающий метод.
*/

namespace HomeWork_10_Task_01
{
    partial class Program
    {
        static void Main(string[] args)
        {

            Program program = new Program();

            Console.WriteLine("ЗАДАЧА 1:");
            program.Task_01();

            Console.WriteLine("\n\nЗАДАЧА 2:");
            program.Task_02();

            Console.WriteLine("\n\nЗАДАЧА 3:");
            program.Task_03();


            Console.ReadKey();
        }
    }
}
