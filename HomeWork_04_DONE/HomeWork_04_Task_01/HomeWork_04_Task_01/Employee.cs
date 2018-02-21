using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace HomeWork_04_Task_01
{
    public class Employee : IComparable
    {

        public string name { get; set; }                //ФИО
        public string address { get; set; }             //адрес
        public DateTime dateOfBirth { get; set; }       //дата рождения
        public string phone { get; set; }               //телефон
        public SEX sex { get; set; }                    //пол
        public POSITION position { get; set; }          //должость
        public DateTime hiringDate { get; set; }        //дата приема на работу
        public double wage { get; set; }                //ЗП

        public Employee(string name, string address, string dateOfBirth, string phone, SEX sex, POSITION position, string hiringDate, double wage)
        {
            this.name = name;
            this.address = address;
            this.dateOfBirth = DateTime.ParseExact(dateOfBirth, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            this.phone = phone;
            this.sex = sex;
            this.position = position;
            this.hiringDate = DateTime.ParseExact(hiringDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            this.wage = wage;
        }

        //перегрузка метода ToString()
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format("ФИО: {0}, пол: {1}\n", name, sex == SEX.MALE ? "мужской" : "женский"));
            sb.Append(String.Format("Дата рождения: {0}\n", dateOfBirth.ToString("dd.MM.yyyy")));
            sb.Append(String.Format("Домашний адрес: {0}, телефон: {1}\n", address, phone));

            string positionRUS = "";
            switch (position)
            {
                case POSITION.BOSS: positionRUS = "директор"; break;
                case POSITION.MANAGER: positionRUS = "менеджер"; break;
                case POSITION.OPERATOR: positionRUS = "оператор"; break;
                case POSITION.SYSADMIN: positionRUS = "сисадмин"; break;
                case POSITION.OFFICE_MANAGER: positionRUS = "офис-менеджер"; break;
            }

            sb.Append(String.Format("Должность: {0}. Дата приема на работу: {1}\n", positionRUS, hiringDate.ToString("dd.MM.yyyy")));
            sb.Append(String.Format("Заработная плата: {0} тенге", wage));

            return sb.ToString();
        }

        //перегрузка метода CompareTo для сортировки по фамилии
        public int CompareTo(object obj)
        {
            Employee temp = (Employee) obj;
            return this.name.CompareTo(temp.name);
        }
    }
}
