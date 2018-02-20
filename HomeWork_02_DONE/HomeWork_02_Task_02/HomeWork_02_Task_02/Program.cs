using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
•	Удалить из строки слова, в которых есть буква 'a'
•	Удалить из строки слова, в которых есть хоть одна буква последнего слова
•	В строке все слова, которые начинаются и заканчиваются одной буквой, выделить квадратными скобками
 */

namespace HomeWork_02_Task_02
{
    class Program
    {
        private static string source = "В более широком смысле под программированием понимают весь спектрс деятельности, связанный с созданием и поддержанием в рабочер состоянии программ — программного обеспечения. Эта инженерно-техническая дисциплинад называется «программная инженерия». Сюда входят анализ и постановка задачиз, проектирование программы, построение алгоритмова, разработка структур данных, написание текстов программ, отладко и тестирование программы (испытания программы), документирование, настройка (конфигурирование), доработка и сопровождение ход.";

        static void Main(string[] args)
        {
            Console.WriteLine("ОРИГИНАЛЬНАЯ СТРОКА:\n{0}\n\n", source);

            //Удалить из строки слова, в которых есть буква 'a'
            string task1 = source;
            Console.WriteLine("Удалили из строки слова, в которых есть буква 'a':");
            DeleteAllWordsWithAGivenLetter(ref task1, 'а');
            Console.WriteLine("-------------------------------------------------------------------------------------------------\n{0}", task1);

            Console.WriteLine("\n");

            //Удалить из строки слова, в которых есть хоть одна буква последнего слова
            string task2 = source;
            Console.WriteLine("Удалили из строки слова, в которых есть хоть одна буква последнего слова:");
            DeleteAllWordsContainingLettersFromLastWord(ref task2);
            Console.WriteLine("-------------------------------------------------------------------------------------------------\n{0}", task2);

            Console.WriteLine("\n");

            //В строке все слова, которые начинаются и заканчиваются одной буквой, выделить квадратными скобками
            string task3 = source;
            Console.WriteLine("В строке все слова, которые начинаются и заканчиваются одной буквой, выделили квадратными скобками:");
            SquareBracesForFirstAndLastLetter(ref task3);
            Console.WriteLine("-------------------------------------------------------------------------------------------------\n{0}", task3);


            Console.ReadKey();
        }


        //Удалить из строки слова, в которых есть буква 'a'
        private static void DeleteAllWordsWithAGivenLetter(ref string source, char letter)
        {
            if (string.IsNullOrWhiteSpace(source))
                return;

            //разбиваем строку на слова
            string[] words = source.Split(' ');
            //обнуляем исходную строку
            source = "";
            //копируем туда слова, в которых нет искомой буквы
            for (int i = 0; i < words.Count(); i++)
            {
                if (!words[i].Contains(letter))
                    source += (words[i] + " ");
            }
            //обрезаем края от пустот
            source.Trim();
        }


        //Удалить из строки слова, в которых есть хоть одна буква последнего слова
        private static void DeleteAllWordsContainingLettersFromLastWord(ref string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                return;

            //разбиваем строку на слова
            string[] words = source.Split(' ');
            //разбиваем последнее слово на буквы
            char[] letters = words[words.Count() - 1].ToCharArray();

            //обнуляем слова, если в них находится хоть одна буква
            for (int i = 0; i < words.Count(); i++)
            {
                for (int j = 0; j < letters.Count(); j++)
                {
                    if (words[i].Contains(letters[j]))
                    {
                        words[i] = "";
                        break;
                    }
                }
            }

            //обнуляем исходную строку
            source = "";
            //копируем туда оставшиеся слова
            foreach (string word in words)
            {
                if (!string.IsNullOrWhiteSpace(word))
                    source += (word + " ");
            }
            //обрезаем края от пустот
            source.Trim();
        }


        //В строке все слова, которые начинаются и заканчиваются одной буквой, выделить квадратными скобками
        private static void SquareBracesForFirstAndLastLetter(ref string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                return;

            //разбиваем строку на слова
            string[] words = source.Split(' ');

            for (int i = 0; i < words.Count(); i++)
            {
                string word = words[i];
                //пропускаем однобуквенные слова
                if (word.Count() < 2)
                    continue;
                //вставляем квадратики
                if (word[0].Equals(word[word.Count() - 1]))
                {
                    word = word.Insert(0, "[").Insert(2, "]");
                    word = word.Insert(word.Count() - 1, "[");
                    word = word.Insert(word.Count(), "]");
                    words[i] = word;
                }
            }

            //обнуляем исходную строку
            source = "";
            //копируем туда измененные слова
            foreach (string word in words)
                source += (word + " ");

            //обрезаем края от пустот
            source.Trim();
        }
    }
}
