using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

/* Напечатать содержимое текстового файла t, выписывая литеры каждой его строки в обратном порядке.*/

/* Дан текстовый файл. За один просмотр файла напечатать элементы файла в следующем порядке: 
 * сначала все слова, начинающиеся на гласную букву, потом все слова, начинающиеся на согласную букву, 
 * сохраняя исходный порядок в каждой группе слов.*/

namespace HomeWork_12_Task_01
{
    partial class Program
    {

        private void Task_03()
        {
            Console.WriteLine("\n\n\nЗАДАЧА 3{0}", divider);

            string path = Path.Combine(Environment.CurrentDirectory, "source.txt");
            List<string> task03 = System.IO.File.ReadLines(path, Encoding.GetEncoding("windows-1251")).ToList();

            //исходная строка
            foreach (string line in task03)
                Console.WriteLine(line);

            Console.WriteLine("\n-----В обратном порядке-----");

            //перевернутая строка
            foreach (string line in task03)
                Console.WriteLine(new string(line.Reverse().ToArray()));
        
            //необходимые регулярные выражения
            Regex vowels = new Regex(@"^[а, о, и, е, ё, э, ы, у, ю, я, a, e, i, o, u]", RegexOptions.IgnoreCase);
            Regex notVowels = new Regex(@"^[^а, о, и, е, ё, э, ы, у, ю, я, a, e, i, o, u]", RegexOptions.IgnoreCase);

            Console.WriteLine("\n-----Сначала слова на гласную букву-----");
            foreach (string line in task03)
                //из line удаляем всю пунктуацию, разбиваем на массив отдельных слов
                //из массива слов возвращаем коллекцию только тех слов, которые начинаются на согласную, потом переводим обратно в массив
                //и создаем новую строку с пробелом как разделитель
                Console.WriteLine(String.Join(" ", (Regex.Replace(line, @"[^\s\w\d]", @"")).Split(' ').Where(word => vowels.IsMatch(word)).ToArray()));

            Console.WriteLine("\n-----Теперь слова на согласную букву-----");
            foreach (string line in task03)
                Console.WriteLine(String.Join(" ", (Regex.Replace(line, @"[^\d\w\s]", @"")).Split(' ').Where(word => notVowels.IsMatch(word)).ToArray()));

        }


    }
}
