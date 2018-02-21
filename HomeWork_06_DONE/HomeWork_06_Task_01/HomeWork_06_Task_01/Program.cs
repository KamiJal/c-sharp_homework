using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

/*
 * 1. Создать абстрактный класс Программное_обеспечение с методами, позволяющими вывести на экран информацию о программном обеспечении, 
 *    а также определить соответствие возможности использования (на момент текущей даты).
 * 2. Создать производные классы: Свободное (название, производитель), Условно-бесплатное (название, производитель, дата установки, срок бесплатного использования), 
 *    Коммерческое (название, производитель, цена, дата установки, срок использования) со своими методами вывода информации на экран, 
 *    и определения возможности использования на текущую дату.
 * 3. Создать базу (массив) из n видов программного обеспечения, вывести полную информацию из базы на экран, а также организовать поиск программного обеспечения, 
 *    которое допустимо использовать на текущую дату.
*/

namespace HomeWork_06_Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            Software[] soft = new Software[0];
            program.TestInitialize(ref soft);

            while (true)
                program.menu(soft);
            
        }


        //меню программы
        private void menu(Software[] soft)
        {
            //проверка ввода
            string choice = "";
            while (!Regex.IsMatch(choice, @"^[1-3]{1}$"))
            {              
                Console.Clear();
                Console.WriteLine("Выберите операцию:\n1. Печать всех программ\n2. Печать доступных программ\n3. Печать программ с истекшим сроком действия");
                choice = Console.ReadLine();
            }

            Console.WriteLine("--------------------------------------------------------------------------------");

            switch (choice)
            {
                case "1": Print(soft, "all"); break;
                case "2": Print(soft, "valid"); break;
                case "3": Print(soft, "nonvalid"); break;
            }

            Console.ReadKey();
        }


        //печать в зависимости от условия
        private void Print(Software[] soft, string option)
        {
            //печатаем все
            if (option.Equals("all"))
            {
                foreach (Software software in soft)
                {
                    software.Print();
                    Console.WriteLine();
                }
                return;
            }

            //печатаем доступные
            if (option.Equals("valid"))
            {
                foreach (Software software in soft)
                {
                    if (software.IsValid())
                    {
                        software.Print();
                        Console.WriteLine();
                    }
                }
                return;
            }

            //печатаем просроченные
            if (option.Equals("nonvalid"))
            {
                foreach (Software software in soft)
                {
                    if (!software.IsValid())
                    {
                        software.Print();
                        Console.WriteLine();
                    }
                }
                return;
            }
        }




        //тестовая инициализация
        private void TestInitialize(ref Software[] soft)
        {
            soft = new Software[8];

            soft[0] = new Shareware("NOD32", "Ghisler", DateTime.Now.AddDays(-15), 30);
            soft[1] = new Freeware("Freemake", "AV Brot");
            soft[2] = new Commercialware("Photoshop", "Adobe", DateTime.Now.AddDays(-28), 60, 2000);
            soft[3] = new Shareware("Total Security", "Kaspersky", DateTime.Now.AddDays(-40), 30);
            soft[4] = new Commercialware("DRAW", "Corel", DateTime.Now.AddDays(-100), 90, 1500);
            soft[5] = new Freeware("Total Commander", "Pros");
            soft[6] = new Shareware("Word", "Microsoft", DateTime.Now.AddDays(-10), 30);
            soft[7] = new Freeware("Notebook", "Microsoft");
        }
    }
}
