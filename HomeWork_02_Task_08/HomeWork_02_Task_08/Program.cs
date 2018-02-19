using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 •	Объявить одномерный (5 элементов ) массив с именем A и двумерный массив (3 строки, 4 столбца) дробных чисел с именем B. 
 * Заполнить одномерный массив А числами, введенными с клавиатуры пользователем, а двумерный массив В случайными числами с помощью циклов. 
 * Вывести на экран значения массивов: массива А в одну строку, массива В — в виде матрицы. Найти в данных массивах общий максимальный элемент,
 * минимальный элемент, общую сумму всех элементов, общее произведение всех элементов, сумму четных элементов массива А, сумму нечетных столбцов массива В.*/

namespace HomeWork_02_Task_08
{
    class Program
    {
        static void Main(string[] args)
        {

            double[] A = new double[5];
            double[,] B = new double[3, 4];
            FillDoubleMatrix(B, 1, 100);
            //счетчик ввода
            int inputCount = 0;             

            while (inputCount < A.Length)
            {
                Console.Clear();
                Console.WriteLine("Пожалуйста введите {0} вещественных чисел (осталось {1}):", A.Length, A.Length-inputCount);
                //меняем точки на запятые, чтобы ввод с точкой тоже проходил
                string input = Console.ReadLine().Replace('.', ',');
                double result;

                if (Double.TryParse(input, out result))
                    //округляем ввод до 2 цифр после запятой
                    A[inputCount++] = Math.Round(result, 2);
            }

            //
            Console.Clear();
            Console.WriteLine("Массив А:");
            Print(A);
            Console.WriteLine("\nМатрица В:");
            Print(B);

            //ищем общий максимум
            double max;
            bool commonMaxFound = CommonMaxOrMin(A, B, out max, "max");
            if(commonMaxFound)
                Console.WriteLine("Общий максимальный элемент: {0}", max);
            else
                Console.WriteLine("Общий максимальный элемент не найден!");

            //ищем общий минимум
            double min;
            bool commonMinFound = CommonMaxOrMin(A, B, out min, "min");
            if (commonMinFound)
                Console.WriteLine("Общий минимальный элемент: {0}", min);
            else
                Console.WriteLine("Общий минимальный элемент не найден!");

            //остальные условия
            Console.WriteLine("Общая сумма всех элементов равно: {0}", Summ(A, B));
            Console.WriteLine("Общее произведение всех элементов равно: {0}", Mult(A, B));
            Console.WriteLine("Cумма четных элементов массива А: {0}", ArraySummEvenElem(A));
            Console.WriteLine("Cумма нечетных столбцов массива В: {0}", MatrixSummOddColumns(B));

            Console.ReadKey();
        }

        private static Random rnd = new Random();

        //заполняет матрицу произвольными числами
        private static void FillDoubleMatrix(double[,] arr, double min, double max)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    arr[i, j] = Math.Round(rnd.NextDouble() * (max - min) + min, 2);
        }

        //методы вывода в консоль
        private static void Print(double[] arr)
        {
            foreach (var item in arr)
                Console.Write(item + "\t\t");

            Console.WriteLine();
        }
        private static void Print(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j] + "\t\t");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        //находит общий максимум или минимум в одномерном и двумерном массивах
        //возвращает true при удаче, иначе false
        //принимает массив, матрицу, возвращаемый результат 
        //и строку, которая позволяет выбрать режим поиска метода (2 варианта: "min" и "max")
        private static bool CommonMaxOrMin(double[] arr, double[,] matrix, out double result, string search)
        {
            result = 0;
            //если режим указан неверно, возвращаем false
            if (!search.Equals("min") || !search.Equals("max"))
                return false;

            //переменная успешности выполнения метода
            bool foundCommonMinOrMax = false;
 
            //переводим двумерный массив в одномерный для удобного поиска общих чисел
            double[] matrixAsArray = new double[matrix.Length];
            int index = 0;
            foreach (double item in matrix)
                matrixAsArray[index++] = item;

            //ищем максимум
            if (search.Equals("max"))
            {
                for (int i = 0; i < arr.Length; i++)
                    for (int j = 0; j < matrixAsArray.Length; j++)
                        if (arr[i] == matrixAsArray[j])
                            if (result < arr[i])
                            {
                                result = arr[i];
                                foundCommonMinOrMax = true;
                            }
            }

            //ищем минимум
            if (search.Equals("min"))
            {
                for (int i = 0; i < arr.Length; i++)
                    for (int j = 0; j < matrixAsArray.Length; j++)
                        if (arr[i] == matrixAsArray[j])
                            if (result > arr[i])
                            {
                                result = arr[i];
                                foundCommonMinOrMax = true;
                            }
            }
            
            return foundCommonMinOrMax;
        }

        //метод суммирует все элементы матрицы и массива
        private static double Summ(double[] arr, double[,] matrix)
        {
            double summ = 0;

            foreach (double item in arr)
                summ += item;

            foreach (double item in matrix)
                summ += item;

            return summ;
        }

        //метод перемножает все элементы матрицы и массива
        private static double Mult(double[] arr, double[,] matrix)
        {
            double mult = 1;

            foreach (double item in arr)
                mult *= item;

            foreach (double item in matrix)
                mult *= item;

            return mult;
        }

        //метод суммирует только четные элементы массива
        private static double ArraySummEvenElem(double[] arr)
        {
            double summ = 0;

            for (int i = 0; i < arr.Length; i+=2)
                summ += arr[i];

            return summ;
        }

        //метод суммирует только нечетные столбцы матрицы
        private static double MatrixSummOddColumns(double[,] matrix)
        {
            double summ = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 1; j < matrix.GetLength(1); j += 2)
                    summ += matrix[i, j];

            return summ;
        }
    }
}
