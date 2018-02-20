using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
•	Обнулить элементы тех строк, на пересечении которых с главной диагональю стоит четный элемент
•	Обнулить элементы тех столбцов, на пересечении которых с главной диагональю стоит четный элемент
•	Удалить те столбцы, в которых встречается хотя бы два одинаковых элемента
*/

namespace HomeWork_02_Task_03
{
    class Program
    {
        private static int rows = 10;
        private static int columns = 10;
        private static int[,] matrix = new int[rows, columns];

        static void Main(string[] args)
        {
            FillMatrix(ref matrix, 1, 9);
            Console.WriteLine("ИСХОДНАЯ МАТРИЦА:\n");
            PrintMatrix(matrix);

            Console.WriteLine("\n");

            //Обнулить элементы тех строк, на пересечении которых с главной диагональю стоит четный элемент
            Console.WriteLine("Обнулить элементы тех строк, на пересечении которых с главной диагональю стоит четный элемент\n");
            int[,] task1 = MatrixDeepCopy();
            DiagonalEvenRowToZero(task1);
            PrintMatrix(task1);

            Console.WriteLine("\n");

            //Обнулить элементы тех столбцов, на пересечении которых с главной диагональю стоит четный элемент
            Console.WriteLine("Обнулить элементы тех столбцов, на пересечении которых с главной диагональю стоит четный элемент\n");
            int[,] task2 = MatrixDeepCopy();
            DiagonalEvenColumnToZero(task2);
            PrintMatrix(task2);

            Console.WriteLine("\n");

            //Удалить те столбцы, в которых встречается хотя бы два одинаковых элемента
            Console.WriteLine("Удалить те столбцы, в которых встречается хотя бы два одинаковых элемента\n");
            int[,] task3 = new int[10, 10];
            FillMatrix(ref task3, 10, 99);
            PrintMatrix(task3);
            Console.WriteLine("-------------------------------------------------------------------------\n");
            DeleteColumnsWithEqualElements(ref task3);
            PrintMatrix(task3);


            Console.ReadKey();
        }



        //Обнулить элементы тех строк, на пересечении которых с главной диагональю стоит четный элемент
        private static void DiagonalEvenRowToZero(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, i] % 2 != 0)
                        break;
                    matrix[i, j] = 0;
                }
            }
        }

        //Обнулить элементы тех столбцов, на пересечении которых с главной диагональю стоит четный элемент
        private static void DiagonalEvenColumnToZero(int[,] matrix)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[j, j] % 2 != 0)
                        break;
                    matrix[i, j] = 0;
                }
            }
        }

        //Удалить те столбцы, в которых встречается хотя бы два одинаковых элемента
        private static void DeleteColumnsWithEqualElements(ref int[,] matrix)
        {

            //для экономии ресурсов, запросим единожды количество строк и стобцов
            int matrixRows = matrix.GetLength(0);
            int matrixColumns = matrix.GetLength(1);

            //текущий столбец
            int[] currentColumn = new int[matrixColumns];
            //индекс текущего столбца
            int currentColumnIndex = 0;
            //массив индексов столбцов, которые будем удалять
            int[] columnsToDelete = new int[matrixRows];
            int columnsToDeleteSize = 0;

            //проходим по всем столбцам матрицы
            while (currentColumnIndex < matrixColumns)
            {
                //заполняем текущий стобец
                for (int row = 0; row < matrixRows; row++)
                    currentColumn[row] = matrix[row, currentColumnIndex];
                //вытаскиваем только уникальные значения из текущего столбца
                int[] unique = currentColumn.Distinct().ToArray();

                //если есть разница в размерах, значит есть повторяющиеся элементы
                //добавляем текущий индекс столбца на удаление
                if (currentColumn.Count() != unique.Count())
                    columnsToDelete[columnsToDeleteSize++] = currentColumnIndex;
                //переходим на следующий столбец
                currentColumnIndex++;
            }

            //если все элементы в столбцах не повторяются, то просто возвращаемся
            if (columnsToDeleteSize == 0)
                return;
            
            //если во всех столбцах есть повторяющиеся элементы, то просто обнуляем матрицу
            if (columnsToDeleteSize == matrixColumns)
            {
                matrix = null;
                return;
            }

            //если же проверки на полное удаление или на полностью уникальную матрицу прошли
            //то продолжаем работать в обычном режиме

            //обережем лишнюю длину массива с индексами на удаление
            Array.Resize(ref columnsToDelete, columnsToDeleteSize);

            //создаем измененную матрицу, с уменьшенным количеством столбцов
            //количество строк останется неизменным, количество столбцов за минусом удаляемых
            int[,] resultMatrix = new int[matrixRows, matrixColumns - columnsToDeleteSize];

            //копируем исходную матрицу в результирующую с пропуском тех столбцов, которые не нужны
            for (int row = 0; row < matrixRows; row++)
            {
                for (int matrixColumn = 0, resultMatrixColumn = 0; matrixColumn < matrixColumns; matrixColumn++)
                {
                    //если индекса текующец колонки нет в индексах на удаление, то копируем ее
                    if (!isMatch(columnsToDelete, matrixColumn))
                        resultMatrix[row, resultMatrixColumn++] = matrix[row, matrixColumn];
                }
            }

            //подменяем исходную матрицу результатом
            matrix = resultMatrix;


        }

        //вспомогательный метод для метода DeleteColumnsWithEqualElements()
        private static bool isMatch(int[] indexes, int value)
        {
            for (int i = 0; i < indexes.Count(); i++)
            {
                if (indexes[i] == value)
                    return true;
            }

            return false;
        }





        //вспомогательные методы для ускорения тестирования
        private static void FillMatrix(ref int[,] matrix, int min, int max)
        {
            Random rand = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rand.Next(min, max);
                }
            }

        }
        private static void PrintMatrix(int[,] matrix)
        {
            if(matrix == null)
                Console.WriteLine("Матрица пуста или не существует!");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "   ");
                }
                Console.WriteLine("\n");
            }
        }
        private static int[,] MatrixDeepCopy()
        {
            int[,] copy = new int[rows, columns];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    copy[i, j] = matrix[i, j];
                }
            }

            return copy;
        }

    }   //class
}       //namespace

