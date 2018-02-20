using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

/* ЗАДАНИЕ 1
 Дана строка символов, состоящая из цифр от 0 до 9 и пробелов. 
 Группы цифр, разделенные пробелами (одним или несколькими) и не содержащие пробелов внутри себя, 
 будем называть словами. Рассматривая эти слова как числа, определить и напечатать сумму чисел, 
 оканчивающихся на цифры 3 или 4.*/

/* ЗАДАНИЕ 2
Дана строка символов. 
Группы символов, разделенные пробелами и не содержащие пробелов внутри себя, 
будем называть словами. Найти количество слов, у которых первый и последний 
символы совпадают между собой (если можно с комментариями).*/

/* ЗАДАНИЕ 3
 Ввести небольшой текст (с пробелами) в строку S. 
 Подсчитать количество слов в строке и вывести все слова в столбик.*/

/* ЗАДАНИЕ 4
 Составьте программу, которая в слове «класс» две одинаковые буквы заменяет цифрой «1»*/

/* ЗАДАНИЕ 5 
Есть строка (любая), нужно удалить из этой строки знаки / и \.*/

/* ЗАДАНИЕ 6
Дан текст. Определить, есть ли в тексте слово one.*/

/* ЗАДАНИЕ 7
 Дан текст. Определить, содержит ли он символы, отличающиеся от букв и цифр.*/

/* ЗАДАНИЕ 8
 Написать программу, подсчитывающую количество цифр в заданной строке*/

/*ЗАДАНИЕ 9
 Составить символьную строку из N звездочек*/

/*ЗАДАНИЕ 10
 Дана строка, посчитать количество вхождений буквы P*/

/* ЗАДАНИЕ 11
 Нужно определить, на какую букв начинается больше всего слов в тексте.
 */

namespace HomeWork_02_Task_10
{
    class Program
    {
        static void Main(string[] args)
        {
            //разделитель для строк
            string divider = "\n----------------------------------------------------------------------------------------------------------\n";
            //строки для тестов по умолчанию
            string default01 = "CSharp разрабатывался как (язык программированияп) 15прикладного уровня для CLR и, как таковой, зависит, прежoneде всеasdгов, от возможностей самой CLR. ";
            string default02 = "Это касается, прежде всего, системы типов CSharp, кото798рая отражает BCL. Присутствие или отсутствие тех или иных выразительныхв осо879бенностей языка диктуется тем, " +
                "может ли конкретная языковая особенность быть транслированат в соответст124вующиес кон79струкции CLR. Так, с развитием CLR от версии 1.1 к 2.0 значительно обогатился и самс CSharp; " +
                "подобногоп взаимодей123ствия следует ожидать и в 13дальнейшем (однако, эта закономерность была нарушена с выходомв C# 3.0, представляющего собойс расширения языка, " +
                "не опирающиеся на рас879ширения платформы .NET). CLR предоставляет C#, как и всем другимд .NET-ориентирован987ным языкам, многие возможности, которых лишены " +
                "«классические» языки программирования. Напримерн, сборка мусора не реализована в самом CSharp, а производится CLR для программ, написанных на CSharp точно так же, " +
                "как это делается для программп на VB.NET, JSharp и др.";

            Console.WriteLine("Строка для тестов 1{0}{1}{0}Строка для тестов 2{0}{2}{0}\n\n\n\n", divider, default01, default02);

            //ЗАДАНИЕ 1
            string task01 = "\t465 798 32 1 321   378 13 \n87 32 774 3 17 89 32 7       ";
            Console.WriteLine("Строка, состоящая из цифр:{0}{1}{0}Сумма чисел, оканчивающихся на 3 и 4 равна: {2}", divider, task01, Task_01(task01));

            //ЗАДАНИЕ 2
            Console.WriteLine("\n\nРаботаем с 1 и 2 строками по умолчанию{0}Количество слов, у которых первый и последний символы совпадают между собой: {1}\n(слова, состоящие из одной буквы не учитываются)",
                divider, Task_02(default01 + default02));

            //ЗАДАНИЕ 3
            string[] task_03 = Task_03(default01);
            Console.WriteLine("\n\nРаботаем с 1 строкой по умолчанию{0}Количество слов в строке = {1}{0}СЛОВА В СТОЛБИК:", divider, task_03.Length);
            Print(task_03);

            //ЗАДАНИЕ 4
            string task04 = "класс";
            Console.WriteLine("\n\nИсходная строка: {1}{0}После замены: {2}", divider, task04, Task_04(task04));

            //ЗАДАНИЕ 5
            string task05 = "https://mailgoogle\\com/mail/u\\0\\#//inbox";
            Console.WriteLine("\n\nИсходная строка: {1}{0}после удаления всех \\ и /: {2}", divider, task05, Task_05(task05));

            //ЗАДАНИЕ 6
            string task06 = "one";
            string result06 = Task_06(default01, task06) ? "ЕСТЬ!" : "НЕТ!";
            Console.WriteLine("\n\nРаботаем с 1 строкой по умолчанию{0}[{1}] в строке {2}", divider, task06, result06);

            //ЗАДАНИЕ 7
            string result07 = Task_07(default01) ? "ЕСТЬ!" : "НЕТ!";
            Console.WriteLine("\n\nРаботаем с 1 строкой по умолчанию{0}Символы, отличающиеся от букв и цифр {1}", divider, result07);

            //ЗАДАНИЕ 8
            Console.WriteLine("\n\nРаботаем с 1 и 2 строками по умолчанию{0}Количество цифр в строке (учитывается каждая отдельная цифра): {1}", divider, Task_08(default01 + default02));

            //ЗАДАНИЕ 9
            int task09 = 12;
            Console.WriteLine("\n\nСоставить символьную строку из {1} звездочек{0}{2}", divider, task09, Task_09(task09));

            //ЗАДАНИЕ 10
            char letter = 'Р';
            Console.WriteLine("\n\nРаботаем с 1 и 2 строками по умолчанию{0}Количество всех вхождений буквы {1}, независимо от регистра равно = {2}", divider, letter, Task_10(default01 + default02, letter));

            //ЗАДАНИЕ 11
            Console.WriteLine("\n\nРаботаем с 1 и 2 строками по умолчанию{0}Больше всего слов начинается на букву: '{1}'", divider, Task_11(default01 + default02));
            Console.WriteLine("(поиск буквы проходил независимо от регистра. Слова, состоящие из одной буквы, не учитывались)");

            Console.ReadKey();
        }

        //ЗАДАНИЕ 1
        private static int Task_01(string numbers)
        {
            //обрезаем пустые края и разбиваем нашу строку по пробеламна отдельные слова
            numbers = numbers.Trim();
            string[] dividedNumbers = Regex.Split(numbers, @"\s+");

            int summ = 0;

            foreach (string number in dividedNumbers)
            {
                //если конец слова оканчивается на 3 или 4
                if (Regex.IsMatch(number, @"[3,4]$"))
                {
                    int result;
                    //если удалось отпарсить
                    if (Int32.TryParse(number, out result))
                        summ += result;
                }
            }

            return summ;
        }

        //ЗАДАНИЕ 2
        private static int Task_02(string input)
        {
            int summ = 0;

            //убираем все, что не цифры и не буквы, обрезаем пустоты по краям и выравниваем регистр
            input = Regex.Replace(input, @"[^\d\w]", @" ").Trim().ToLower();

            //делим строку на слова с помощью пробелов
            string[] words = Regex.Split(input, @"\s+");

            foreach (string word in words)
            {
                //если слово состоит из одной буквы - пропускаем
                if (word.Length < 2)
                    continue;

                //если первая и последняя буквы одинаковые - прибавляем к сумме
                if (word[0] == word[word.Length - 1])
                    summ++;
            }

            return summ;
        }

        //ЗАДАНИЕ 3
        private static string[] Task_03(string input)
        {
            //убираем все знаки препинания, цифры и обрезаем пустоты по краям у строки
            input = Regex.Replace(input, @"[^\w]", @" ").Trim();

            //разбиваем строку на слова с помощью пробелов
            return Regex.Split(input, @"\s+");
        }

        //ЗАДАНИЕ 4
        private static string Task_04(string input)
        {
            //ищем вхождение любой буквы два раза в конце слова и заменяем на цифру 1
            return Regex.Replace(input, @"\w{2}$", @"1");
        }

        //ЗАДАНИЕ 5
        private static string Task_05(string input)
        {
            //удаляем все / и \
            return Regex.Replace(input, @"[\\/]+", @"");
        }

        //ЗАДАНИЕ 6
        private static bool Task_06(string input, string pattern)
        {
            return Regex.IsMatch(input, pattern);
        }

        //ЗАДАНИЕ 7
        private static bool Task_07(string input)
        {
            return Regex.IsMatch(input, @"\W");
        }

        //ЗАДАНИЕ 8
        private static int Task_08(string input)
        {
            //удаляем все не цифры и считаем длину строки
            return Regex.Replace(input, @"[^\d]", @"").Length;
        }

        //ЗАДАНИЕ 9
        private static string Task_09(int number)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < number; i++)
                sb.Append('*');

            return sb.ToString();
        }

        //ЗАДАНИЕ 10
        private static int Task_10(string input, char letter)
        {
            int count = 0;

            //инициализируем регулярное выражение по букве с игнорирование регистра
            Regex regex = new Regex(letter.ToString(), RegexOptions.IgnoreCase);
            //находим первод совпадение
            Match match = regex.Match(input);

            //ищем совпадения, пока не закончатся
            while (match.Success)
            {
                count++;
                match = match.NextMatch();
            }

            return count;
        }

        //ЗАДАНИЕ 11
        private static char Task_11(string input)
        {
            //очищаем строку от не букв
            input = Regex.Replace(input, @"[^\w]", @" ").Trim().ToLower();

            //делим строку на слова
            string[] words = Regex.Split(input, @"\s+");

            //создаем массив символов только с первыми буквами каждого слова
            char[] firstLetters = new char[words.Length];
            //счетчик размера массива символов
            int firstLettersSize = 0;

            //заполняем массив символов первыми буквами каждого слова
            foreach (string word in words)
            {
                if (word.Length < 2)
                    continue;
                firstLetters[firstLettersSize++] = word[0];
            }

            //обрезаем лишние символы в массиве
            Array.Resize(ref firstLetters, firstLettersSize);

            //создаем еще один массив только с уникальными буквами, с которым мы будем сравнивать
            char[] uniqueLetters = firstLetters.Distinct().ToArray();

            //переменные для хранения текущего максимума повторов и буквы
            char maxLetter = '\0';
            int maxLetterCount = 0;

            for (int i = 0; i < uniqueLetters.Length; i++)
            {
                //счетчик повторов текущей буквы в цикле
                int currentLetterCount = 0;
                for (int j = 0; j < firstLetters.Length; j++)
                {
                    //если буквы равны, текущий счетчик увеличивается
                    if (uniqueLetters[i] == firstLetters[j])
                        currentLetterCount++;
                }

                //если текущий счетчик больше, чем основной
                //обновляем основной и устанавливаем букву текущей
                if (currentLetterCount > maxLetterCount)
                {
                    maxLetterCount = currentLetterCount;
                    maxLetter = uniqueLetters[i];
                }
            }

            return maxLetter;
        }


        //ПЕЧАТЬ МАССИВА СТРОК
        private static void Print(string[] words)
        {
            foreach (string word in words)
                Console.WriteLine(word);
        }
    }
}
