using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_04_Task_03
{
    //ЗАДАЧА 3
    public struct Employee
    {
        public string name;
        public VACANCIES vacancy;
        public int wage;
        public int[] hiredDate;

        public Employee(string name, VACANCIES vacancy, int wage, int[] hireDate) 
        {
            this.name = name;
            this.vacancy = vacancy;
            this.wage = wage;
            this.hiredDate = new int[3];
            Array.Copy(this.hiredDate, hiredDate, 3);
        }
    }
}
