using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * Написать программу, которая считывает символы с клавиатуры, 
 * пока не будет введена точка. Программа должна сосчитать 
 * количество введенных пользователем пробелов.
 */

namespace HomeWork_02_Task_04
{
    class Program
    {
        static void Main(string[] args)
        {
            char input = '-';       //вводимый символ
            int spacesCount = 0;    //счетчик пробелов

            //идем по циклу до первой точки
            while (input != '.')
            {
                
                input = (char)Console.Read();
                
                //проверяем по условию
                if (input.Equals(' '))
                    spacesCount++;
            }

            Console.WriteLine("Количество введенных пробелов до первой точки: {0}", spacesCount);

            Console.ReadKey();
        }
    }
}
