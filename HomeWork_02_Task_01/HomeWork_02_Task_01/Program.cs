using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
•	Напечатать весь массив целых чисел
•	Найти индекс максимального значения в массиве
•	Найти индекс максимального четного значения в массиве
•	Удалить элемент из массива по индексу.
•	Удаление элементов из массива по значению
•	Вставить элемент в массив по индексу
•	Удалить те элементы массива, которые встречаются в нем ровно два раза
 */

namespace HomeWork_02_Task_01
{
    class Program
    {
        private static Random rand = new Random();
        private static int[] source = new int[20];
        private static void FillResource()
        {
            for (int i = 0; i < source.Count(); i++)
            {
                source[i] = rand.Next(1, 100);
            }
        }


        static void Main(string[] args)
        {
            FillResource();

            //Напечатать весь массив целых чисел
            Console.WriteLine("Заданный массив:");
            PrintAll(source);

            Console.WriteLine("\n");

            //Найти индекс максимального значения в массиве
            Console.Write("Индекс максимального значения в массиве: {0}", MaxIndex(source));

            Console.WriteLine("\n");

            //Найти индекс максимального четного значения в массиве
            Console.Write("Индекс максимального четного значения в массиве: {0}", MaxIndexOfEvenOnly(source));

            Console.WriteLine("\n");

            //Удалить элемент из массива по индексу
            DeleteByIndex(ref source, 5);
            Console.WriteLine("Массив после удаления элемента под индексом 5:");
            PrintAll(source);

            Console.WriteLine("\n");

            //Удаление элементов из массива по значению
            Console.WriteLine("Массив после удаления элемента со значением {0}:", source[8]);
            DeleteByValue(ref source, source[8]);
            PrintAll(source);

            Console.WriteLine("\n");

            //Вставить элемент в массив по индексу
            Console.WriteLine("Вставляем элемент 111 в начало массива, 333 в конец массива, а 222 на 5 индекс массива:");
            InsertByIndex(ref source, 0, 111);
            InsertByIndex(ref source, source.Count() + 1, 333);
            InsertByIndex(ref source, 5, 222);
            PrintAll(source);

            Console.WriteLine("\n");

            //Удалить те элементы массива, которые встречаются в нем ровно два раза
            Console.WriteLine("Вставляем еще по одному элементу 111 и 222 в массив и 2 элемента со значением 333:");
            InsertByIndex(ref source, 9, 111);
            InsertByIndex(ref source, 15, 222);
            InsertByIndex(ref source, 3, 333);
            InsertByIndex(ref source, 11, 333);
            PrintAll(source);
            Console.WriteLine("\nУдаляем те элементы, которые встречаются ровно 2 раза (333, которое встречается 3 раза, осталось):");
            DeleteTwoEqualElements(ref source);
            PrintAll(source);

            Console.WriteLine("\n");



            Console.ReadKey();
        }

        //Напечатать весь массив целых чисел
        private static void PrintAll(int[] source)
        {
            if (source == null)
                Console.Write("массив не существует!"); ;

            foreach (int number in source)
                Console.Write(number + " ");
        }

        //Найти индекс максимального значения в массиве
        private static int MaxIndex(int[] source)
        {
            if (source == null)
                return -1;

            int max = source[0];
            int index = 0;

            for (int i = 1; i < source.Count(); i++)
            {
                if (source[i] > max)
                {
                    max = source[i];
                    index = i;
                }
            }

            return index;
        }

        //Найти индекс максимального четного значения в массиве
        private static int MaxIndexOfEvenOnly(int[] source)
        {
            if (source == null)
                return -1;

            int max = 0;
            int index = 0;

            for (int i = 0; i < source.Count(); i++)
            {
                if (source[i] % 2 == 0 && max < source[i])
                {
                    max = source[i];
                    index = i;
                }
            }

            return index;
        }

        //Удалить элемент из массива по индексу
        private static void DeleteByIndex(ref int[] source, int index)
        {
            if (source == null || index < 0 || index > source.Count())
                return;

            int[] temp = new int[source.Count() - 1];
            for (int i = 0, j = 0; i < source.Count(); i++)
                if (i != index)
                {
                    temp[j] = source[i];
                    j++;
                }

            source = temp;
        }

        //Удаление элементов из массива по значению
        private static void DeleteByValue(ref int[] source, int value)
        {
            if (source == null || !source.Contains(value))
                return;

            int[] temp = new int[source.Count()];
            int tempSize = 0;

            for (int i = 0; i < source.Count(); i++)
                if (source[i] != value)
                {
                    temp[tempSize++] = source[i];
                }

            Array.Resize(ref temp, tempSize);
            source = temp;
        }

        //Вставить элемент в массив по индексу
        private static void InsertByIndex(ref int[] source, int index, int value)
        {
            if (source == null || index < 0 || index > source.Count() + 2)
                return;

            //вставка в конец массива
            if (index == source.Count() + 1)
            {
                //увеличиваем размер массива и вставляем число в конец
                Array.Resize(ref source, source.Count() + 1);
                source[source.Count() - 1] = value;
                return;
            }

            //массив для работы
            int[] temp = new int[source.Count() + 1];

            //вставка в начало массива
            if (index == 0)
            {
                //вставляем числов начало
                temp[0] = value;
                //копируем все остальное
                for (int i = 0; i < source.Count(); i++)
                {
                    temp[i + 1] = source[i];
                }

                source = temp;
                return;
            }

            //вставка в середину

            //копируем до индекса
            for (int i = 0; i < index; i++)
                temp[i] = source[i];

            //вставляем наше число
            temp[index] = value;

            //копируем остатки
            for (int i = index; i < source.Count(); i++)
                temp[i + 1] = source[i];

            source = temp;

        }

        //Удалить те элементы массива, которые встречаются в нем ровно два раза
        private static void DeleteTwoEqualElements(ref int[] source)
        {
            //находим только уникальные элементы
            int[] unique = source.Distinct().ToArray();
            //счетчик пар
            int pairs = 0;
            //этот массив будет хранить только те значения, которые парные
            //размер зададим разницей между основным и уникальным
            //а точное количество парных элементов будет считать переменная pairs
            int[] pairsValues = new int[source.Count() - unique.Count()];

            //считаем точное количество пар и записываем парные значение в наш массив
            for (int i = 0; i < unique.Count(); i++)
            {
                int count = 0;
                for (int j = 0; j < source.Count(); j++)
                {
                    if (unique[i] == source[j])
                        count++;
                }

                if (count == 2)
                    pairsValues[pairs++] = unique[i];

            }

            //удаляем из основного массива все пары
            for (int i = 0; i < pairs; i++)
            {
                Console.WriteLine("Парное значение {0} удалено из массива!", pairsValues[i]);
                DeleteByValue(ref source, pairsValues[i]);
            }



        }
    }
}
