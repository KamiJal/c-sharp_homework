using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

/* Дан файл, содержащий числа. За один просмотр файла напечатать элементы файла в следующем порядке: 
 * сначала все положительные числа, потом все отрицательные числа, 
 * сохраняя исходный порядок в каждой группе чисел.*/

namespace HomeWork_12_Task_01
{
    partial class Program
    {
        private void Task_04()
        {
            Console.WriteLine("\n\n\nЗАДАЧА 4{0}", divider);

            string path = Path.Combine(Environment.CurrentDirectory, "numbers.txt");
            string input = System.IO.File.ReadAllText(path, Encoding.GetEncoding("windows-1251"));

            Console.WriteLine(input);

            int number;
            Console.WriteLine("\n-----Положительные в том же порядке-----");
            Console.WriteLine(String.Join(" ", Regex.Split(input, @"\s+").Where(word => Int32.TryParse(word, out number) && number > 0).ToArray()));

            Console.WriteLine("\n-----Отрицательные в том же порядке-----");
            Console.WriteLine(String.Join(" ", Regex.Split(input, @"\s+").Where(word => Int32.TryParse(word, out number) && number < 0).ToArray()));

            
        }
    }
}
