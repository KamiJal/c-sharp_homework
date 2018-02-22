using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Создать коллекцию List <int> . 
 * Вывести на экран позицию и значение элемента, являющегося вторым максимальным значением в коллекции. 
 * Вывести на экран сумму элементов на четных позичиях.
 * Удалить все нечетные элементы списка List<int>*/

namespace HomeWork_12_Task_01
{
    partial class Program
    {
        private void Task_01()
        {

            Console.WriteLine("ЗАДАЧА 1{0}", divider);

            List<int> task01 = new List<int>();

            for (int i = 0; i < 15; i++)
                task01.Add(rnd.Next(1, 1000));

            foreach (int number in task01)
                Console.Write(number + " ");

            //сортируем по убыванию и берем второй элемент
            int secondMax = task01.OrderByDescending(number => number).Take(2).ElementAt(1);
            //индекс второго максимума
            int secondMaxIdx = task01.IndexOf(secondMax);
            //сумма элементов на четных позициях
            int evenSumm = task01.Where((number, index) => index % 2 == 0).Sum();
            //удаляем все нечетные элементы
            task01 = task01.Where((number, index) => index % 2 == 0).ToList();


            Console.WriteLine("\nВторое максимальное значение в коллекции: {0}, индекс {1}", secondMax, secondMaxIdx);
            Console.WriteLine("Сумма элементов на четных позициях равна: {0}", evenSumm);
            Console.WriteLine("После удаления всех элементов с нечетными индексами:");
            foreach (int number in task01)
                Console.Write(number + " ");

        }


    }
}
