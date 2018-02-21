using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
2.	Для получения места в общежитии формируется список студентов, который включает 
 * Ф.И.О. студента, группу, средний балл, доход на члена семьи, пол (перечисление), 
 * форма обучения(перечисление). Общежитие в первую очередь предоставляется тем, 
 * у кого доход на члена семьи меньше двух минимальных зарплат, затем остальным в порядке 
 * уменьшения среднего балла. Вывести список очередности предоставления мест в общежитии. */

namespace HomeWork_04_Task_02
{
    class Program
    {
        //массив студентов
        private static Student[] students;
        //МЗП в Казахстане на 2018 год
        private static double MZP = 28284;
        //разделитель для вывода
        private static string divider = "\n--------------------------------------------------------------------------------\n";

        static void Main(string[] args)
        {
            Program program = new Program();

            //тестовая инициализация
            program.TestStudentInitilize();
            //сортируем сразу по среднему баллу
            Array.Sort(students);

            Console.WriteLine("МИНИМАЛЬНАЯ ЗАРАБОТНАЯ ПЛАТА: {1} тенге{0}\n", divider, MZP);

            Console.WriteLine("СПИСОК ВСЕХ СТУДЕНТОВ:{0}", divider);
            program.Print();

            Console.WriteLine("\n\n\nСПИСОК ОЧЕРЕДНОСТИ ПРЕДОСТАВЛЕНИЯ МЕСТ В ОБЩЕЖИТИИ:{0}", divider);
            program.QueuePrint();
            


            Console.ReadKey();
        }


        //печать списка очередности предоставления мест в общежитии
        private void QueuePrint()
        {
            //скопируем основной список во временный
            Student[] queueTemp = new Student[students.Length];
            Array.Copy(students, queueTemp, students.Length);

            Console.WriteLine("СТУДЕНТЫ С ДОХОДОМ НА ЧЛЕНА СЕМЬИ НИЖЕ ДВУХ МЗП:\n");

            //сначала выводим всех, у кого ЗП на члена семьи ниже двух МЗП
            //и удаляем студента из временного списка
            for (int i = 0; i < queueTemp.Length; i++)
                if (queueTemp[i].familyPersonIncome < MZP * 2)
                {
                    Console.WriteLine(queueTemp[i] + divider);
                    queueTemp[i] = null;
                }

            Console.WriteLine("\nСТУДЕНТЫ С ДОХОДОМ НА ЧЛЕНА СЕМЬИ ВЫШЕ ДВУХ МЗП:\n");

            //выводим оставшихся студентов
            foreach (var student in queueTemp)
                if (student != null)
                    Console.WriteLine(student + divider);
        }

        //печатает весь список студентов
        private void Print()
        {
            foreach (var student in students)
                Console.WriteLine(student + divider);
        }






        //метод для быстрого теста
        private void TestStudentInitilize()
        {
            students = new Student[5];
            students[0] = new Student("Назаров Фома Иннокентиевич", "PMP-162", 35000, SEX.MALE, EDUCATIONFORM.INTERNALLY);
            students[1] = new Student("Лачинов Феофан Давыдович", "PMP-161", 58400, SEX.MALE, EDUCATIONFORM.INTERNALLY);
            students[2] = new Student("Церетели Аркадий Проклович", "PUP-132", 43800, SEX.MALE, EDUCATIONFORM.IN_ABSENTIA);
            students[3] = new Student("Пронина Таисия Мефодиевна", "PMP-161", 110000, SEX.MALE, EDUCATIONFORM.INTERNALLY);
            students[4] = new Student("Чюличков Максимильян Серафимович", "PUP-132", 74500, SEX.MALE, EDUCATIONFORM.IN_ABSENTIA);
        }
    }
}
