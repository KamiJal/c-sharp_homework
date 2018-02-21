using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
1.	Разработать один из классов на ваше усмотрение.
2.	Реализовать не менее пяти закрытых полей (различных типов), представляющих основные характеристики рассматриваемого класса.
3.	Создать не менее трех методов управления классом и методы доступа к его закрытым полям. 
4.	Создать метод, в который передаются аргументы по ссылке. 
5.	Создать не менее двух статических полей (различных типов),  представляющих общие характеристики объектов данного класса. 
6.	Обязательным требованием является реализация нескольких перегруженных конструкторов, аргументы которых определяются студентом, исходя из специфики реализуемого класса, 
    а так же реализация конструктора по умолчанию.
7.	Создать статический конструктор.
8.	Создать массив (не менее 5 элементов) объектов созданного класса.
9.	Создать дополнительный метод для данного класса в другом файле, используя ключевое слово partial. 
Варианты (по выбору):
    1. автомобиль;
    2. мотоцикл;
    3. самолет;
    4. Бытовая техника (на выбор);
    5. Продукты питания (на выбор);
    6. канцелярские товары (на выбор);
    7. мебель (на выбор);
    8. ракета;
    9. Поезд;
    10. зажигалка.
*/

namespace HomeWork_05_Task_01
{
    class Program
    {
        //разделитель для вывода
        private static string divider = "\n--------------------------------------------------------------------------------\n";

        static void Main(string[] args)
        {
            Program program = new Program();
            Moto[] motoList = new Moto[15];

            Console.WriteLine("Количество мотоциклов до добавления: {0}", Moto.motoCount);
            Console.WriteLine("Общая стоимость мотоциклов до добавления: {0:N} тенге\n\n", Moto.maxPrice);

            Console.WriteLine("ДОБАВЛЕННЫЕ МОТОЦИКЛЫ:\n");
            program.TestMotoListInitialize(ref motoList);
            program.Print(motoList);

            Console.WriteLine("\nКоличество мотоциклов после добавления: {0}", Moto.motoCount);
            Console.WriteLine("Общая стоимость мотоциклов после добавления: {0:N} тенге", Moto.maxPrice);

            Console.ReadKey();
        }

        //печать всех мотоциклов
        private void Print(Moto[] motolist)
        {
            foreach (var moto in motolist)
                Console.WriteLine("{0}Дополнительно:\nМощность = {1} кВт, стоимость в USD = {2}${3}", moto, moto.getKwt().ToString("N1"), moto.priceInUSD().ToString("N2"), divider);
        }

        //метод с передачей параметра по ссылке
        private void TestMotoListInitialize (ref Moto[] motoList)
        {
            motoList = new Moto[5];
            motoList[0] = new Moto(MOTOMAKER.KAWASAKI, "ZX6R", 636, 280, 119, 1200000);
            motoList[1] = new Moto(MOTOMAKER.HONDA, "CBR600RR", 600, 300, 124, 1600000);
            motoList[2] = new Moto(MOTOMAKER.HARLEY_DAVIDSON, "Road Glide", 636, 240, 86, 11000000);
            motoList[3] = new Moto(MOTOMAKER.YAMAHA, "YZR-6", 600, 290, 114, 1350000);
            motoList[4] = new Moto(MOTOMAKER.DUCATTI, "Monster", 1000, 260, 99, 5500000);
        }

    }
}
