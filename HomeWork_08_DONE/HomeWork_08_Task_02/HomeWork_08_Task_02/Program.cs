using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HUMAN;

namespace HomeWork_08_Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
          
            //создаем наш генератор
            HumanGenerator hg = new HumanGenerator();

            //генерируем мужчину
            Human man = hg.GenerateDefault(SEX.MALE);

            //генерируем женщину
            Human woman = hg.GenerateDefault(SEX.FEMALE);

            //печать
            Console.WriteLine("СГЕНЕРИРОВАНЫ ПРОИЗВОЛЬНЫЕ МУЖЧИНА И ЖЕНЩИНА\n");

            Console.WriteLine(man);
            Console.WriteLine();
            Console.WriteLine(woman);

            Console.ReadKey();
        }
    }
}
