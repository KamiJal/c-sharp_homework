using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Даны 2 строки s1 и s2. Из каждой можно читать по одному символу. Выяснить, является ли строка s2 обратной s1.*/

namespace HomeWork_12_Task_01
{
    partial class Program
    {
        private void Task_05()
        {

            Console.WriteLine("\n\n\nЗАДАЧА 5{0}", divider);

            string s1 = "Коварный всемогущая наш жизни семь, агенство дал, языком!";
            string s2 = "Текстов о, ему несколько имеет!";
            string s3 = new string(s1.Reverse().ToArray());

            Console.WriteLine("Строка 1: {0}\nСтрока 2: {1}\nСтрока 3: {2}", s1, s2, s3);
            Console.WriteLine("Соответствует ли строка 2 обратной строкой 1: {0}", checkReverse(s1, s2));
            Console.WriteLine("Соответствует ли строка 3 обратной строкой 1: {0}", checkReverse(s1, s3));

        }

        private bool checkReverse(string s1, string s2)
        {
            //выясняем какая строка меньше, чтобы не выйти за пределы массива
            int minLength = s1.Length < s2.Length ? s1.Length : s2.Length;

            for (int i = 0; i < minLength; i++)
            {
                if (s1[i] != s2[s2.Length - 1 - i])
                    return false;
            }

            return true;
        }

    }
}
