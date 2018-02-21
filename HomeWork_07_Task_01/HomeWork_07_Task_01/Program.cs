using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

/*Разработать программу, моделирующую танковый бой. 
В танковом бою участвуют 5 танков «Т-34» и 5 танков «Pantera». Каждый танк («Т-34» и «Pantera») описываются параметрами: «Боекомплект», «Уровень брони», «Уровень маневренности». 
 * Значение данных параметров задаются случайными числами от 0 до 100. Каждый танк участвует в парной битве, т.е. первый танк «Т-34» сражается с первым танком «Pantera» и т. д. 
 * Победа присуждается тому танку, который превышает противника по двум и более параметрам из трех (пример: см. программу). Основное требование: сражение (проверку на победу в бою) 
 * реализовать путем перегрузки оператора «*» (произведение). 
1.	В решение добавить новый проект с именем «Day7 (Tanks)», в котором будут промоделированы танковые сражения. В данный проект добавить ссылку на библиотеку классов «MyClassLib».
2.	В библиотеке классов «MyClassLib» создать папку «WordOfTanks», а в ней разработать класс с именем «Tank».
В классе должно быть реализовано
●	Поля
закрытые поля, предназначенные для представления
1.	Названия танка.
2.	Уровня боекомплекта танка.
3.	Уровня брони. 
4.	Уровня маневренности.
●	Конструктор
Конструктор с параметрами, обеспечивающий инициализацию всех полей класса Tank. При этом Боекомплект, Уровень брони, Уровень маневренности инициализируются случайными числами от 0 до 100 %. 
 * Название танка передаются в конструктор из функции Main(). 
●	Перегрузка оператора «^»(произведение)
При перегрузке оператора «^» (произведение) должна быть реализована проверка на победу в бою одного танка по отношению к другому. Критерий победы — победивший танк должен превышать 
 * проигравший танк не менее чем по двум из трех параметров (Боекомплект, Уровень брони, Уровень маневренности). 
●	Методы:
Получение текущих значений параметров танка: Бое­комплект, Уровень брони, Уровень маневренности в виде строки.

Важно! При разработке программы использовать обработку исключительных ситуаций. Варианты возможных исключительных ситуаций рассмотреть самостоятельно!
*/

namespace HomeWork_07_Task_01
{
    class Program
    {
        //массивы левой и правой команд
        //можно легко сменить количество участвующих в сражении танков
        private static int bothSize = 5;
        private static Tank[] teamLeft;
        private static Tank[] teamRight;

        static void Main(string[] args)
        {
            Program program = new Program();
            program.TestInitialize();
            program.Fight();
        }


        //метод, реализующий бой
        private void Fight()
        {
            int leftWins = 0;
            int rightWins = 0;

            try
            {
                Console.WriteLine("НАЧИНАЕТСЯ БОЙ МЕЖДУ {0} ТАНКАМИ Т-34 И PANTERA...", bothSize);
                Thread.Sleep(2000);
                
                for (int i = 0; i < bothSize; i++)
                {
                    Console.WriteLine("\n\n{0}\nСРАЖАЕТСЯ С\n{1}", teamLeft[i], teamRight[i]);
                    Thread.Sleep(4000);

                    Console.WriteLine("--------------------------------------------------------");

                    if (teamLeft[i] * teamRight[i])
                    {
                        Console.WriteLine("ПОБЕДУ ОДЕРЖАЛ: {0}", teamLeft[i].name);
                        leftWins++;
                    }
                    else
                    {
                        Console.WriteLine("ПОБЕДУ ОДЕРЖАЛ: {0}", teamRight[i].name);
                        rightWins++;
                    }

                    Thread.Sleep(2000);
                }
            }
            //если вместо танка будет null
            catch (ArgumentNullException e) { Console.WriteLine(e.StackTrace); }

            string teamWonName = (leftWins > rightWins) ? teamLeft[0].name : teamRight[0].name;

            Console.WriteLine("\n\nПОЗДРАВЛЯЕМ КОМАНДУ ТАНКОВ {0} С ПОБЕДОЙ!!!", teamWonName);

            Console.ReadKey();
        }

        //тестовая инициализация 5 танков
        private void TestInitialize()
        {         
            teamLeft = new Tank[bothSize];
            teamRight = new Tank[bothSize];

            try
            {
                for (int i = 0; i < bothSize; i++)
                {
                    teamLeft[i] = new Tank("Т-34");
                    teamRight[i] = new Tank("PANTERA");
                }
            }
            // если выйдем за пределы массива
            catch (IndexOutOfRangeException e) { Console.WriteLine(e.StackTrace); }
        }
    }
}
