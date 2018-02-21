using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

/*
 * 1.	Создать массив сотрудников. Длина массива задается пользователем, заполнение массива производится им же. Выполнить следующее:
        a.	вывести полную информацию обо всех сотрудниках;
        b.	найти в массиве всех менеджеров, зарплата которых больше средней зарплаты всех клерков, 
            вывести на экран полную информацию о таких менеджерах отсортированной по их фамилии.
        c.	распечатать информацию обо всех сотрудниках, принятых на работу позже босса, отсортированную в алфавитном порядке по фамилии сотрудника.
*/

namespace HomeWork_04_Task_01
{
    class Program
    {
        //список сотрудников
        private static Employee[] staff;
        //разделитель для вывода
        private static string divider = "\n--------------------------------------------------------------------------------\n";

        static void Main(string[] args)
        {
            Program program = new Program();

            //тестовая инициализация
            //program.TestStaffInitilize();

            //инициализируем массив сотрудников
            program.UserStaffInitialize();

            //отсортируем массив сотрудников по фамилии
            Array.Sort(staff);

            Console.WriteLine("СПИСОК ВСЕХ СОТРУДНИКОВ:\n");
            program.Print();
            Console.WriteLine("\n\n\nСПИСОК СОТРУДНИКОВ, У КОТОРЫХ ЗП ВЫШЕ СРЕДНЕГО:\n");
            program.PrintAvg(FindAvgWage());
            Console.WriteLine("\n\n\nСПИСОК СОТРУДНИКОВ, ПРИНЯТЫХ НА РАБОТУ ПОЗЖЕ ДИРЕКТОРА:\n");
            program.PrintAfterBoss();

            Console.ReadKey();
        }




        //заполнение массива сотрудников пользователем
        private void UserStaffInitialize()
        {
            //переменная для проверок
            bool success = false;

            //ввод размера массива сотрудников с проверкой
            int staffSize = 0;
            while (!success)
            {
                Console.Clear();
                Console.WriteLine("Введите размер массива сотрудников:");   
                success = Int32.TryParse(Console.ReadLine(), out staffSize) && staffSize > 0;
            }
            staff = new Employee[staffSize];

            //счетчик сотрудников
            int employeeCount = 0;

            //ввод сотрудников
            while (employeeCount < staff.Length)
            {
                //переменные для данных о сотруднике
                string name =  null;
                string address = null;
                string dateOfBirth = null;
                string phone = null;
                SEX sex = SEX.NOT_DEFINED;
                POSITION position = POSITION.NOT_DEFINED;
                string hireDate = null;
                double wage = 0;

                //ввод фамилии
                Console.Clear();
                Console.WriteLine("Введите ФИО сотрудника:");
                name = Console.ReadLine();

                //ввод адреса
                Console.Clear();
                Console.WriteLine("Введите адрес сотрудника");
                address = Console.ReadLine();             

                //ввод даты рождения с проверкой
                success = false;
                while (!success)
                {
                    Console.Clear();
                    Console.WriteLine("Введите дату рождения в формате \"гггг-мм-дд\"");
                    dateOfBirth = Console.ReadLine();
                    success = DateCheck(dateOfBirth, "birth");
                }

                //ввод телефона с проверкой
                success = false;
                while (!success)
                {
                    Console.Clear();
                    Console.WriteLine("Введите номер телефона в формате 81234567891");
                    phone = Console.ReadLine();
                    success = Regex.IsMatch(phone, @"8\d{10}");              
                }               

                //ввод пола c проверкой
                success = false;
                while (!success)
                {
                    Console.Clear();
                    Console.WriteLine("Выберите пол\n1. мужской\n2. женский");
                    string choice = Console.ReadLine();
                    success = Regex.IsMatch(choice, @"^[1-2]${1}");
                    sex = choice.Equals("1") ? SEX.MALE : SEX.FEMALE;
                }

                //ввод должности c проверкой
                success = false;
                while (!success)
                {
                    Console.Clear();
                    Console.WriteLine("Выберите должность\n1. директор\n2. менеджер\n3. оператор\n4. сисадмин\n5. офис-менеджер");
                    string choice = Console.ReadLine();
                    success = Regex.IsMatch(choice, @"^[1-5]${1}");

                    switch (choice)
                    {
                        case "1": position = POSITION.BOSS; break;
                        case "2": position = POSITION.MANAGER; break;
                        case "3": position = POSITION.OPERATOR; break;
                        case "4": position = POSITION.SYSADMIN; break;
                        case "5": position = POSITION.OFFICE_MANAGER; break;
                    }
                }

                //ввод даты приема на работу с проверкой
                success = false;
                while (!success)
                {
                    Console.Clear();
                    Console.WriteLine("Введите дату приема на работу в формате \"гггг-мм-дд\"");
                    hireDate = Console.ReadLine();
                    success = DateCheck(hireDate, "hire");
                }

                //ввод ЗП с проверкой
                success = false;
                while (!success)
                {
                    Console.Clear();
                    Console.WriteLine("Введите ЗП сотрудника (мин: 50000, макс: 800000) в тенге");
                    string input = Console.ReadLine();
                    success = Double.TryParse(input, out wage) && wage > 49999 && wage < 800001;
                }

                //инициализация нового сотрудника
                staff[employeeCount++] = new Employee(name, address, dateOfBirth, phone, sex, position, hireDate, wage);
            }
        }

        //метод проверки даты на валидность
        private bool DateCheck(string date, string option)
        {

            DateTime check;

            //если введенная дата совсем не парсится, то возвращаем false
            if(!DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out check))
                return false;

            //если вводим дату рождения, то сотрудник должен быть не старше 63 лет (пенсионер) и ему должно быть полных 18 лет
            if (option.Equals("birth"))
                return check > DateTime.Now.AddYears(-63) && check < DateTime.Now.AddYears(-18);

            //предположим, что дата образования компании - 01.01.2000
            //поэтому прием будет с этой даты и не позднее сегодняшнего числа
            if (option.Equals("hire"))
                return check > new DateTime(2000, 01, 01) && check <= DateTime.Now;

            return false;
        }

        //метод ищет среднюю ЗП по сотрудникам
        private static double FindAvgWage()
        {
            double wageSumm = 0;

            foreach (var employee in staff)
                wageSumm += employee.wage;

            return wageSumm / staff.Length;
        }

        //печатает всех сотрудников
        private void Print()
        {
            foreach (var employee in staff)
                Console.WriteLine(employee + divider);
        }

        //печатает сотрудников, у кого ЗП выше среднего
        //включая директора, так как он тоже сотрудник
        private void PrintAvg(double averageWage)
        {
            Console.WriteLine("Средняя ЗП сотрудников, включая директора: {0}\n", averageWage);

            foreach (var employee in staff)
                if (employee.wage > averageWage)
                    Console.WriteLine(employee + divider);
        }

        //печатает сотрудников, которые приняты позже директора
        private void PrintAfterBoss()
        {
            //ищем дату приема на работу директора
            DateTime bossHiredDate = DateTime.Now;

            foreach (var employee in staff)
                if (employee.position == POSITION.BOSS)
                    bossHiredDate = employee.hiringDate;

            Console.WriteLine("Дата приема на работу директора: {0}\n", bossHiredDate.ToString("dd.MM.yyyy"));

            //печатаем всех, кого приняли позже
            foreach (var employee in staff)
                if (employee.hiringDate > bossHiredDate)
                    Console.WriteLine(employee + divider);
        }



        //метод для быстрого теста
        private void TestStaffInitilize()
        {
            staff = new Employee[5];
            staff[0] = new Employee("Назаров Фома Иннокентиевич", "Алматы, 258", "1968-05-23", "87077892147", SEX.MALE, POSITION.MANAGER, "2016-11-15", 200000);
            staff[1] = new Employee("Лачинов Феофан Давыдович", "Алматы, 162", "1974-03-15", "87072347895", SEX.MALE, POSITION.BOSS, "2017-05-05", 450000);
            staff[2] = new Employee("Церетели Аркадий Проклович", "Алматы, 54", "1988-07-05", "87071347812", SEX.MALE, POSITION.OPERATOR, "2017-07-24", 120000);
            staff[3] = new Employee("Пронина Таисия Мефодиевна", "Алматы, 38", "1992-02-18", "87071334782", SEX.FEMALE, POSITION.OFFICE_MANAGER, "2018-01-24", 80000);
            staff[4] = new Employee("Чюличков Максимильян Серафимович", "Алматы, 147", "1978-09-08", "87076347815", SEX.MALE, POSITION.SYSADMIN, "2016-08-02", 250000);
        }
    }
}
