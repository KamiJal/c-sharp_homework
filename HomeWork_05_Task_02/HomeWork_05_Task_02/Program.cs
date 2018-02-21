using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Необходимо создать класс — зоомагазин. 
 * В классе должны быть следующие поля: животное ( напр. волк, пингвин, собака ), 
 * пол, имя, цена, количество. 
 * Включить в состав класса необходимый минимум методов, обеспечивающий полноценное функционирование объектов указанного класса:

a.	Конструкторы (по умолчанию, с параметрами);
b.	Добавить необходимые методы.
*/

namespace HomeWork_05_Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            ZooMagazine zoo = new ZooMagazine();
            zoo.TestInitialize();
            zoo.Print();

            Console.ReadKey();
        }
    }
}
