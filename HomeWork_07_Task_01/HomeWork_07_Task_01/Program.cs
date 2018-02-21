using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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
