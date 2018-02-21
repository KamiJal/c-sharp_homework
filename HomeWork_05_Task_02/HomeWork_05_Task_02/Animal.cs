using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_05_Task_02
{
    //абстрактный класс животное
    public abstract class Animal
    {
        public string type { private set; get; }
        public string name { private set; get; }
        public ANIMAL_SEX sex { private set; get; }
        public double price { private set; get; }

        protected Animal(string type, string name, ANIMAL_SEX sex, double price) {
            this.type = type;
            this.name = name;
            this.sex = sex;
            this.price = price;
        }

        //печать животного
        public override string ToString(){
            string sexDecription = "";

            switch (sex)
            {
                case ANIMAL_SEX.MALE: sexDecription = "мальчик"; break;
                case ANIMAL_SEX.FEMALE: sexDecription = "девочка"; break;
                case ANIMAL_SEX.NOT_DEFINED: sexDecription = "не установлено"; break;
            }

            return String.Format("{0} по кличке {1}, пол: {2}, стоимость: {3:N}$", type, name, sexDecription, price);
        }
    }
}
