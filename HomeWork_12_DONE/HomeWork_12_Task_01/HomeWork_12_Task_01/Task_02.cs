using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Дана коллекция типа List<double>. Вывести на экран элементы списка, 
 * значение которых больше среднего арифметического всех элементов коллекции.*/


namespace HomeWork_12_Task_01
{
    partial class Program
    {
        private void Task_02()
        {

            Console.WriteLine("\n\n\nЗАДАЧА 2{0}", divider);

            List<double> task02 = new List<double>();

            for (int i = 0; i < 15; i++)
                task02.Add(rnd.NextDouble()*(100-1) + 1);

            foreach (double number in task02)
                Console.Write("{0:N2}  ", number);

            Console.WriteLine("\nСреднее арифметическое в коллекции: {0:N2}", task02.Average());
            Console.WriteLine("Элементы списка, значение которых больше среднего арифметического всех элементов коллекции:");
            
            foreach (double number in task02.Where(number => number > task02.Average()))
                Console.Write("{0:N2}  ", number);

        }
    }
}
