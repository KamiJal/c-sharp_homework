using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_07_Task_03
{
    public class Test
    {
        public static Random rnd = new Random();
        public int[] elements { private set; get; }

        public Test(int size)
        {
            elements = new int[size];

            //заполняем автоматически для тестирования
            for (int i = 0; i < size; i++)
            {
                elements[i] = rnd.Next(1, 100);
            }
        }

        public static bool operator >(Test t1, Test t2)
        {
            return t1.Summ() > t2.Summ();
        }

        public static bool operator <(Test t1, Test t2)
        {
            return t1.Summ() < t2.Summ();
        }


        //метод для подсчета суммы элементов
        private long Summ()
        {
            long summ = 0;

            foreach (int value in elements)
                summ += value;

            return summ;
        }
    }
}
