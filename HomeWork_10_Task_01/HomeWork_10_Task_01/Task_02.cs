using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_10_Task_01
{
    partial class Program
    {
        public void Task_02()
        {
            int[] arr = new int[5];
            try
            {
                for (int i = 0; i <= arr.Length; i++)
                    arr[i] = i + 1;
            }
            catch (IndexOutOfRangeException e) { Console.WriteLine(e.Message); }
            finally { Console.WriteLine("Обработка массива завершена!"); }

        }
    }
}
