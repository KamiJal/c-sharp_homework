using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

/*  1. Создать абстрактный класс Trans с методами позволяющим вывести на экран информацию о транспортном средстве, а также определить грузоподъемность транспортного средства.
    2. Создать производные классы: Легковая_машина (марка, номер, скорость, грузоподъемность), Мотоцикл (марка, номер, скорость, грузоподъемность, наличие коляски, 
       при этом если коляска отсутствует, то грузоподъемность равна 0), Грузовик (марка, номер, скорость, грузоподъемность, наличие прицепа, при этом если есть прицеп, 
       то грузоподъемность увеличивается в два раза) со своими методами вывода информации на экран, и определения грузоподъемности.
    3. Создать базу (массив) из n машин, вывести полную информацию из базы на экран, а также организовать поиск машин, удовлетворяющих требованиям грузоподъемности.
*/

namespace HomeWork_06_Task_03
{
    class Program
    {
        //массив транспортных средств
        private static Trans[] trans;

        static void Main(string[] args)
        {
            Program program = new Program();
            program.TestInitialize();

            while (true)
                program.Menu();
        }



        //меню программы
        private void Menu()
        {
            //проверка ввода
            string choice = "";
            while (!Regex.IsMatch(choice, @"^[1-5]{1}$"))
            {
                Console.Clear();

                Console.WriteLine("Выберите операцию:\n1. Все транспортные средства\n" +
                    "2. Мотоциклы\n3. Легковые машины\n4. Грузовики\n5. Введите вес груза для поиска подходящей машины");
                choice = Console.ReadLine();
            }

            Console.WriteLine("--------------------------------------------------------------------------------");

            switch (choice)
            {
                case "1": Print(TRANS_TYPE.ALL); break;
                case "2": Print(TRANS_TYPE.MOTO); break;
                case "3": Print(TRANS_TYPE.CAR); break;
                case "4": Print(TRANS_TYPE.TRUCK); break;
                case "5": PrintByCarriage(); break;
            }

            Console.ReadKey();
        }

        //ищем возможные транспортные средства, которые могли бы выполнить заказ
        //при вводе необходимой грузоподъемности
        private void PrintByCarriage()
        {
            double carrying = 0;
            bool success = false;

            while (!success)
            {
                Console.Clear();
                Console.WriteLine("Введите вес груза в кг.");
                string input = Console.ReadLine();
                success = Double.TryParse(input, out carrying);
            }

            Console.WriteLine("\nДОСТУПНЫЕ ВАРИАНТЫ:");
            Console.WriteLine("--------------------------------------------------------------------------------");

            foreach (var tran in trans)
            {
                if(tran.carrying > carrying)
                    Console.WriteLine(tran + "\n");
            }

        }


        //печать по условию
        private void Print(TRANS_TYPE type)
        {
            //печатаем все
            if (type == TRANS_TYPE.ALL)
            {
                foreach (var tran in trans)
                    Console.WriteLine(tran + "\n");
                return;
            }

            //печатаем только выбор
            foreach (var tran in trans)
                if (tran.type == type)
                    Console.WriteLine(tran + "\n");
        }



        //тестовая инициализация
        private void TestInitialize()
        {
            trans = new Trans[8];
            trans[0] = new Moto("Kawasaki ZX6R", "KW636", 280, 120, false);
            trans[1] = new Car("Mitsubishi FTO", "FTO200", 180, 300);
            trans[2] = new Moto("Honda CBR600", "CB600", 300, 80, false);
            trans[3] = new Truck("Iveco 500", "IVC500", 220, 40000, false);
            trans[4] = new Car("Subaru Impreza", "SUB160", 200, 450);
            trans[5] = new Moto("ИЖ 505", "BA453", 120, 150, true);
            trans[6] = new Truck("Suzuki H400", "SUZ400", 160, 10000, true);
            trans[7] = new Truck("Mercedes-Benz Actros", "MB800", 240, 50000, true);
        }
    }
}
