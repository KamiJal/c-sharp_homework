using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_04_Task_02
{
    class Student : IComparable
    {
        public string name { get; set; }
        public string group { get; set; }
        public double avgPoints { get; set; }
        public double familyPersonIncome { get; set; }
        public SEX sex { get; set; }
        public EDUCATIONFORM educationform { get; set; }

        public Student(string name, string group, double familyPersonIncome, SEX sex, EDUCATIONFORM educationform)
        {
            this.name = name;
            this.group = group;
            this.familyPersonIncome = familyPersonIncome;
            this.sex = sex;
            this.educationform = educationform;

            //для примера возьмем расчет среднего балла как доход на члена семьи деленное на форму обучения деленное на 1000
            //чем хуже форма обучения, тем хуже балл, значит выше очередность получения места в общежитии
            avgPoints = familyPersonIncome / (int)educationform / 1000;
        }

        //перегрузка метода ToString()
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(String.Format("ФИО: {0}, пол: {1}\n", name, sex == SEX.MALE ? "мужской" : "женский"));
            sb.Append(String.Format("Группа {0}, форма обучения: {1}\n", group, educationform == EDUCATIONFORM.INTERNALLY ? "очно" : "заочно"));
            sb.Append(String.Format("Средний балл: {0}\n", avgPoints));
            sb.Append(String.Format("Доход на члена семьи: {0} тенге\n", familyPersonIncome));

            return sb.ToString();
        }

        //перегрузка метода CompareTo для сортировки по фамилии
        public int CompareTo(object obj)
        {
            Student temp = (Student)obj;
            return this.avgPoints.CompareTo(temp.avgPoints);
        }
    }
}
