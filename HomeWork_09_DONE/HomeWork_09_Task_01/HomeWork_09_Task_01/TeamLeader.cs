using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HomeWork_09_Task_01
{
    public class TeamLeader : IWorker
    {
        public string GetWorkerName()
        {
            return this.GetType().Name;
        }

        public void BuildHouse(House house) {

            Console.WriteLine("Проверяю дом...");
            Thread.Sleep(3000);

            //если бейзмента нет, значит еще не начинали работать
            if (house.basement == null)
            {
                Console.WriteLine("Пока ничего не построено!");
                Thread.Sleep(2000);
                return;
            }
            //либо есть
            Console.WriteLine("Фундамент построен!");


            Thread.Sleep(1000);


            //проверка стен
            int wallsDone = 0;
            //считаем сколько готово
            for (int i = 0; i < house.walls.Length; i++)
            {
                if (house.walls[i] != null)
                    wallsDone++;
            }
            //если нет готовых, просто возвращаемся
            if(wallsDone == 0)
                return;
            //если меньше 4
            if (wallsDone < 4)
            {
                Console.WriteLine("Построено {0} стены", wallsDone);
                Thread.Sleep(1000);
                return;
            }
            //либо все готово
            if(wallsDone == 4)
                Console.WriteLine("Все стены построены!");


            Thread.Sleep(1000);


            //проверка двери
            if (house.door == null)
                return;
            //готово
            Console.WriteLine("Дверь установлена!");


            Thread.Sleep(1000);


            //проверка окон
            int windowsDone = 0;
            //считаем сколько готово
            for (int i = 0; i < house.windows.Length; i++)
            {
                if (house.windows[i] != null)
                    wallsDone++;
            }
            //если нет готовых, просто возвращаемся
            if (windowsDone == 0)
                return;
            //если меньше 4
            if (windowsDone < 4)
            {
                Console.WriteLine("Установлено {0} окно(-а)", wallsDone);
                Thread.Sleep(1000);
                return;
            }
            //либо все готово
            if (windowsDone == 4)
                Console.WriteLine("Все окна установлены!");


            Thread.Sleep(1000);


            //проверка крыши
            if (house.roof == null)
                return;
            //готово
            Console.WriteLine("Крыша установлена!");

            Thread.Sleep(1000);
        }
    }
}
