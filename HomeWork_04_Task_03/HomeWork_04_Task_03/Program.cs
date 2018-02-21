using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
1. Создать перечисление должностей Vacancies {Manager, Boss, Clerk, Salesman, и т.д.}
2. Создайте класс Кошка. У кошки будет свойство «уровень сытости» и метод «съесть что-то». Создайте перечисление Еда (рыба, мышь…). Каждый вид еды должен по-разному изменять уровень сытости.
3. Создать структуру «Employee» состоящую из:
    a. поля name строкового типа;
    b. поля vacancy типа Vacancies;
    c. поля зарплата целого типа;
    d. поля дата приема на работу типа int[3].
*/

namespace HomeWork_04_Task_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat();

            Console.WriteLine("Начальный уровень сытости мыши: {0}\n", cat.satiety);

            cat.EatSomething(FOOD.PASTRY);
            Console.WriteLine("Уровень сытости мыши: {0}\n", cat.satiety);
            cat.EatSomething(FOOD.WHISKAS);
            Console.WriteLine("Уровень сытости мыши: {0}\n", cat.satiety);
            cat.EatSomething(FOOD.MOUSE);
            Console.WriteLine("Уровень сытости мыши: {0}\n", cat.satiety);


            Console.ReadKey();
        }
    }
}
