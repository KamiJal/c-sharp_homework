using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

/*
 * 1. Создать абстрактный класс Товар с методами, позволяющими вывести на экран информацию о товаре, а также определить, соответствует ли она искомому типу.
 * 2. Создать производные классы: 
     * Игрушка (название, цена, производитель, материал, возраст, на который рассчитана), 
     * Книга (название, автор, цена, издательство, возраст, на который рассчитана), 
     * Спорт-инвентарь (название, цена, производитель, возраст, на который рассчитана), 
     * со своими методами вывода информации на экран, и определения соответствия искомому типу.
 * 3. Создать базу (массив) из n товаров, вывести полную информацию из базы на экран, а также организовать поиск товаров определенного типа.
*/

namespace HomeWork_06_Task_02
{
    class Program
    {
        //массив продуктов
        private static Product[] products;

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
            while (!Regex.IsMatch(choice, @"^[1-4]{1}$"))
            {
                Console.Clear();

                Console.WriteLine("Выберите операцию:\n1. Печать всех товаров\n" +
                    "2. Печать игрушек\n3. Печать книг\n4. Печать спорт. инвентаря");
                choice = Console.ReadLine();
            }

            Console.WriteLine("--------------------------------------------------------------------------------");

            switch (choice)
            {
                case "1": Print(PRODUCT_TYPE.ALL); break;
                case "2": Print(PRODUCT_TYPE.TOY); break;
                case "3": Print(PRODUCT_TYPE.BOOK); break;
                case "4": Print(PRODUCT_TYPE.SPORT_STUFF); break;
            }

            Console.ReadKey();
        }


        //печать по условию
        private void Print(PRODUCT_TYPE type)
        {
            //печатаем все
            if (type == PRODUCT_TYPE.ALL)
            {
                foreach (var product in products)
                    Console.WriteLine(product + "\n");
                return;
            }

            //печатаем только выбор
            foreach (var product in products)
                if (product.type == type)
                    Console.WriteLine(product + "\n");
        }



        //тестовая инициализация
        private void TestInitialize()
        {
            products = new Product[8];
            products[0] = new Toy("Batmobile", MATERIAL.METAL, 2500, "Hot Wheels", 5);
            products[1] = new Book("Хроники Заводной Птицы", "Харуки Мураками", 2500, "МоскваПринт", 18);
            products[2] = new Sport_Stuff("футбольный мяч", 9000, "Sela", 7);
            products[3] = new Toy("Познайка", MATERIAL.WOOD, 4000, "Россман", 3);
            products[4] = new Sport_Stuff("скакалка", 2000, "SportMaster", 5);
            products[5] = new Book("Из чего это сделано", "Планета", 3500, "ЭльдаПринт", 7);
            products[6] = new Toy("Звезда смерти", MATERIAL.PLASTIC, 12000, "Lego", 12);
            products[7] = new Book("Мойдодыр", "Корней Чуковский", 800, "Герона", 3);
        }

    }
}
