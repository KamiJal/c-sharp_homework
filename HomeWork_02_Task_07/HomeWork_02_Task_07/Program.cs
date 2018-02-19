using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*ЗАДАНИЕ 1:    Даны целые положительные числа A и B (A < B). 
 *              Вывести все целые числа от A до B включительно; 
 *              каждое число должно выводиться на новой строке; 
 *              при этом каждое число должно выводиться количество раз, 
 *              равное его значению. Например: если А = 3, а В = 7, 
 *              то программа должна сформировать в консоли следующий вывод:
                3 3 3
                4 4 4 4
                5 5 5 5 5
                6 6 6 6 6 6
                7 7 7 7 7 7 7
*/

/*ЗАДАНИЕ 2:    
 * Дано целое число N (> 0), найти число, полученное при прочтении 
 * числа N справа налево. Например, если было введено число 345, 
 * то программа должна вывести число 543.
*/

/* ЗАДАНИЕ 3
 * Даны 2 массива размерности M и N соответственно. 
 * Необходимо переписать в третий массив общие элементы 
 * первых двух массивов без повторений.*/



namespace HomeWork_02_Task_07
{
    class Program
    {
        static void Main(string[] args)
        {
            //ЗАДАНИЕ 1
            Console.WriteLine("ЗАДАНИЕ 1");
            int A = 3, B = 7;
            Console.WriteLine("Даны числа А = {0}, B = {1}", A, B);
            PrintFromAToB(A, B);

            //ЗАДАНИЕ 2
            Console.WriteLine("\nЗАДАНИЕ 2");
            int N = 87546;
            Console.WriteLine("Дано число {0}, найти число, полученное при прочтении исходного справа налево.", N);
            ReverseNumber(N);

            //ЗАДАНИЕ 3
            Console.WriteLine("\nЗАДАНИЕ 3");
            int[] arr1 = new int[10];
            int[] arr2 = new int[15];
            FillIntArray(arr1, 1, 50);
            FillIntArray(arr2, 1, 50);
            Console.Write("Даны 2 массива. Необходимо переписать в третий массив общие элементы первых двух массивов без повторений\nМассив 1: ");
            PrintArray(arr1);
            Console.Write("\nМассив 2: ");
            PrintArray(arr2);
            int[] result = MergeArraysUnique(arr1, arr2);
            Console.Write("\nРезультрующий массив: ");
            PrintArray(result);

            //ЗАДАНИЕ 4
            Console.WriteLine("\n\nЗАДАНИЕ 4");
            int[,] matrix = new int[5, 5];
            FillIntMatrix(matrix, -100, 100);
            PrintMatrix(matrix);
            int min, max;
            Console.WriteLine("Сумма элементов между минимальным ({1}) и максимальным ({2}) равна: {0}", SummBetweenMinAndMaxInMatrix(matrix, out min, out max), min, max);

            Console.ReadKey();
        }

        //ЗАДАНИЕ 1
        private static void PrintFromAToB(int A, int B)
        {
            //если число слишком маленькое
            if (A > B || A < 1 || B < 1 || A == B)
                return;

            while (A <= B)
            {
                string output = "";
                for (int i = 0; i < A; i++)
                {
                    output += (A + " ");
                }

                Console.WriteLine(output.Trim());
                A++;
            }
        }

        //ЗАДАНИЕ 2
        private static void ReverseNumber(int number)
        {
            if (number < 1)
                return;

            char[] reverse = number.ToString().ToCharArray();
            Array.Reverse(reverse);
            string result = new string(reverse);
            Console.WriteLine("Получившееся число: {0}", result);
        }

        //ЗАДАНИЕ 3
        private static int[] MergeArraysUnique(int[] arr1, int[] arr2)
        {
            //создаем результирующий массив размером с самый большой из двух входных
            int[] process = new int[(arr1.Length > arr2.Length ? arr1.Length : arr2.Length)];
            int processIndex = 0;

            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr2.Length; j++)
                {
                    if (arr1[i] == arr2[j])
                        process[processIndex++] = arr1[i];
                }
            }

            Array.Resize(ref process, processIndex);

            return process.Distinct().ToArray(); ;
        }

        //ЗАДАНИЕ 4
        private static int MinMaxInMatrix(int[,] matrix, bool findMin, out int rIdx, out int cIdx)
        {
            int result = matrix[0, 0];
            rIdx = cIdx = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (findMin)
                    {
                        if (matrix[i, j] < result)
                        {
                            result = matrix[i, j];
                            rIdx = i;
                            cIdx = j;
                        }
                    }
                    else
                        if (matrix[i, j] > result)
                        {
                            result = matrix[i, j];
                            rIdx = i;
                            cIdx = j;
                        }
                }
            }

            return result;
        }
        private static int SummBetweenMinAndMaxInMatrix(int[,] matrix, out int min, out int max)
        {
            int summ = 0;

            //находим минимум и максимум в матрице и их индексы
            int minRowIdx, minColIdx;
            min = MinMaxInMatrix(matrix, true, out minRowIdx, out minColIdx);
            int maxRowIdx, maxColIdx;
            max = MinMaxInMatrix(matrix, false, out maxRowIdx, out maxColIdx);

            //служит для обнуления нумерации столбцов, кроме первого раза
            int loopFirstLaunch = 0;

            for (int i = (minRowIdx < maxRowIdx ? minRowIdx : maxRowIdx); i < matrix.GetLength(0); i++)
            {
                //при первом запуске цикла важно начать с элемента, который идет следующим после мин или макс (в зависимости, что раньше начинается)
                //на втором круге начинаем с 0
                int j = (loopFirstLaunch++ == 0 ? (i == minRowIdx ? minColIdx + 1 : maxColIdx + 1) : 0);

                for (; j < matrix.GetLength(1); j++)
                {
                    //как только мы доходим до правого элемента (либо мин либо макс), то возращаем сумму
                    if ((i == minRowIdx && j == minColIdx) || (i == maxRowIdx && j == maxColIdx))
                        return summ;

                    summ += matrix[i, j];
                }
            }

            return summ;
        }


        //ВСПОМОГАТЕЛЬНЫЕ ЭЛЕМЕНТЫ ДЛЯ ТЕСТИРОВАНИЯ
        private static Random rnd = new Random();
        private static void FillIntMatrix(int[,] arr, int min, int max)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rnd.Next(min, max);
                }
            }
        }
        private static void FillIntArray(int[] arr, int min, int max)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(min, max);
            }
        }
        private static void PrintArray(int[] arr)
        {
            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }
        }
        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }




    }
}
