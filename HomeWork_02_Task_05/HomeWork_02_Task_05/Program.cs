using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Ввести с клавиатуры номер трамвайного билета (6-значное число) и 
 * проверить является ли данный билет счастливым (если на билете напечатано шестизначное число, 
 * и сумма первых трёх цифр равна сумме последних трёх, то этот билет считается счастливым).*/

namespace HomeWork_02_Task_05
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                string input;               //переменная для ввода
                int result;                 //переменная для парсинга

                Console.Clear();
                Console.WriteLine("Введите шестизначный номер билета для проверки на удачу:");
                input = Console.ReadLine().Trim();      //считываем и сразу обрезаем пробелы

                //если ввод содержит меньше 6 символов или не парсится - значит ввели неверно
                if (input.Length != 6 || !Int32.TryParse(input, out result))
                {
                    Console.WriteLine("Вы ввели неверное значение! Попробуйте снова.");
                    Console.ReadKey();
                    continue;
                }

                int leftSideSumm = 0;       //сумма 3 левых цифр
                int rightSideSumm = 0;      //сумма 3 правых цифр

                for (int i = 0; i < input.Length; i++)
                {
                    //парсим каждую цифру
                    Int32.TryParse(input[i].ToString(), out result);

                    //суммируем либо с левой, либо с правой стороной
                    if (i < 3)
                        leftSideSumm += result;
                    else
                        rightSideSumm += result;
                }

                //вывод
                if (leftSideSumm == rightSideSumm)
                    Console.WriteLine("Поздравляем! У вас счастливый билет!");
                else
                    Console.WriteLine("К сожалению вам не повезло! Билет не счастливый!");


                Console.ReadKey();
            }


        }
    }
}
