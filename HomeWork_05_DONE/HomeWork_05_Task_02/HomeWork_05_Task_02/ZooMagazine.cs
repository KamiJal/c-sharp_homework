using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_05_Task_02
{
    public class ZooMagazine
    {
        //животные
        public Animal[] animals { private set; get; }
        //общее количество животных
        public int animalQuantity { private set; get; }

        public ZooMagazine() : this(0) { }
        public ZooMagazine(int quantity)
        {
            this.animalQuantity = quantity;
            this.animals = new Animal[animalQuantity];
        }

        //печать всего зоомагазина
        public void Print()
        {
            string divider = "\n--------------------------------------------------------------------------------\n";

            Console.WriteLine("ЗООМАГАЗИН:\n\n");

            foreach (Animal animal in animals)
                Console.WriteLine(animal + divider);

            Console.WriteLine("\nОбщее количество всех животных в магазине: {0} единиц", animalQuantity);
        }

        //тестовая инициализация
        public void TestInitialize()
        {
            this.animals = new Animal[5];
            animalQuantity = 5;

            animals[0] = new Wolf("Акелла", ANIMAL_SEX.MALE, 400);
            animals[1] = new Penguin("Бромгильла", ANIMAL_SEX.FEMALE, 800);
            animals[2] = new Bear("Миша", ANIMAL_SEX.MALE, 1200);
            animals[3] = new Dog("Граф", ANIMAL_SEX.MALE, 100);
            animals[4] = new Wolf("Герда", ANIMAL_SEX.FEMALE, 500);
        }
    }
}
