using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

/*Пользователь вводит строку. Проверить, является ли эта строка палиндромом. 
 * Палиндромом называется строка, которая одинаково читается слева направо и справа налево. 
 * Подсчитать количество слов во введенном предложении. */

/* Примеры палиндромов:
        Кони, топот, инок, 
        Но не речь, а черен он. 
        Идем, молод, долом меди. 
        Чин зван мечем навзничь. 
        Голод, чем меч долог? 
        Пал, а норов худ и дух ворона лап. 
        А что? Я лав? Воля отча! 
        Яд, яд, дядя! 
        Иди, иди! 
        Мороз в узел, лезу взором. 
        Солов зов, воз волос. 
        Колесо. Жалко поклаж. Оселок. 
        Сани, плот и воз, зов и толп и нас. 
        Горд дох, ход дрог. 
        И лежу. - Ужели? 
        Зол, гол лог лоз. 
        И к вам и трем с смерти мавки.
*/

namespace HomeWork_02_Task_09
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";

            while (String.IsNullOrWhiteSpace(input))
            {
                Console.Clear();
                Console.WriteLine("Введите строку для проверки, является ли она полиндромом\n(при сравнении все пробелы, цифры, знаки препинания и мягкий знак будут опущены):");
                input = Console.ReadLine().Trim();
            }

            //считаем количество слов
            //для этого делим строку по любым символьным пробелам
            Regex spaces = new Regex(@"\s");
            string[] words = spaces.Split(input);
            Console.WriteLine("\nКоличество слов во введенной строке: {0}\n", words.Length);

            //убираем все, что не буквы и мягкий знак, выравниваем регистр
            string notLetters = @"[\d\W\sь]";
            string result = Regex.Replace(input, notLetters, "").ToLower();

            //проверяем соответствие левой и правой половинок
            bool polindrom = true;
            for (int i = 0; i < result.Length / 2 && polindrom; i++)
                if (result[i] != result[result.Length - 1 - i])
                    polindrom = false;

            //результат
            if (polindrom)
                Console.WriteLine("Строка:\n{0}\nявляется полиндромом!", input);
            else
                Console.WriteLine("Строка не является полиндромом!");


            Console.ReadKey();
        }
    }
}
