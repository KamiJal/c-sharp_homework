using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

/*1.	Реализовать программу “Строительство дома” 
Реализовать: 
●	Классы
○	House (Дом), Basement (Фундамент), Walls (Стены), Door (Дверь), Window (Окно), Roof (Крыша);
○	Team (Бригада строителей), Worker (Строитель), TeamLeader (Бригадир).
●	Интерфейсы
○	IWorker, IPart.
Все части дома должны реализовать интерфейс IPart (Часть дома), для рабочих и бригадира предоставляется базовый интерфейс IWorker (Рабочий).  
 * Бригада строителей (Team) строит дом (House). Дом состоит из фундамента (Basement), стен (Wall), окон (Window), дверей (Door), крыши (Part).
Согласно проекту, в доме должно быть 1 фундамент, 4 стены, 1 дверь, 4 окна и 1 крыша. 
Бригада начинает работу, и строители последовательно “строят” дом, начиная с фундамента. Каждый строитель не знает заранее, 
 * на чём завершился предыдущий этап строительства, поэтому он “проверяет”, что уже построено и продолжает работу. 
 * Если в игру вступает бригадир (TeamLeader), он не строит, а формирует отчёт, что уже построено и какая часть работы выполнена. 
В конечном итоге на консоль выводится сообщение, что строительство дома завершено и отображается “рисунок дома” 
 * (вариант отображения выбрать самостоятельно).
*/

namespace HomeWork_09_Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Team team = new Team();
            House house = new House();

            string divider = "--------------------------------------------";

            Console.WriteLine("НАЧИНАЕМ СТРОИТЕЛЬСТВО ДОМА...\n{0}", divider);
            Thread.Sleep(2000);

            while (!house.IsReady)
            {
                IWorker active = team.GetRandomWorker();

                Console.WriteLine("Активный работник: {0}", active.GetWorkerName());
                active.BuildHouse(house);

                if(active.GetWorkerName() == "TeamLeader")
                    Console.WriteLine("ПРОВЕРКА ОКОНЧЕНА!");

                Console.WriteLine(divider);
                Thread.Sleep(3000);
            }

            Console.WriteLine("УРА! ДОМ УСПЕШНО ПОСТРОЕН!\n");
            Thread.Sleep(2000);

            Console.WriteLine("А ВОТ И ОН!\n\n");
            Thread.Sleep(2000);

            Console.WriteLine(HousePic.drawHouse());


            Console.ReadKey();
        }
    }
}
