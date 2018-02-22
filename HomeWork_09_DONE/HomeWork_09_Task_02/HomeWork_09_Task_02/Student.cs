using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_09_Task_02
{
    public class Student : IStudent
    {
        public string Name { set; get; }
        public string FullName { set; get; }
        public int[] Grades { set; get; }

        public string GetName()
        {
            return this.Name;
        }

        public string GetFullName()
        {
            return this.FullName;
        }

        public double GetAvgGrade()
        {
            int summ = 0;

            foreach (int grade in Grades)
                summ += grade;
            return (double)summ / Grades.Length;
        }
    }
}
