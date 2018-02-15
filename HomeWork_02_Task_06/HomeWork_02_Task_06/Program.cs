using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*•	Числовые значения символов нижнего регистра в коде ASCII отличаются от значений символов верхнего регистра на величину 32. 
 * Используя эту информацию, написать программу, которая считывает с клавиатуры и конвертирует все символы нижнего регистра в символы верхнего регистра и наоборот.*/

namespace HomeWork_02_Task_06
{
    class Program
    {
        static void Main(string[] args)
        {

            string input;

            //проверка ввода на пустую строку
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите строку:");
                input = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(input))
                    break;
            }

            int choice;

            //выбор условия перевода строки с проверкой ввода
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Ваша строка:\n{0}\n", input);
                Console.WriteLine("Для перевода строки:\nв нижний регистр, нажмите 1\nв верхний регистр, нажмите 2");
                string choiceInput = Console.ReadLine().Trim();
                if (Int32.TryParse(choiceInput, out choice))
                    if (choice == 1 || choice == 2)
                        break;
            }

            //массив символов для изменения
            char[] convert = input.ToCharArray();

            switch (choice)
            {
                case 1:
                    {
                        for (int i = 0; i < convert.Length; i++)
                        {
                            int letter = convert[i];
                            if ((letter > 64 && letter < 91) || (letter > 1039 && letter < 1072))       //проверяем, входит ли наша буква в диапазон вернего регистра в русском и английском
                                convert[i] = (char)(letter + 32);
                        }
                    } break;
                case 2:
                    {
                        for (int i = 0; i < convert.Length; i++)
                        {
                            int letter = convert[i];
                            if ((letter > 96 && letter < 123) || (letter > 1071 && letter < 1104))      //проверяем, входит ли наша буква в диапазон нижнего регистра в русском и английском
                                convert[i] = (char)(letter - 32);
                        }
                    } break;
            }


            string result = "";

            for (int i = 0; i < convert.Length; i++)
            {
                result += convert[i];
            }

            Console.WriteLine("\n{0}", result);



            Console.ReadKey();
        }
    }
}
