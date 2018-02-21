using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_06_Task_02
{
    public class Toy : Product
    {
        public MATERIAL material { private set; get; }      //материал изготовления

        public Toy() : this("нет данных", MATERIAL.NOT_DEFINED) { }
        public Toy(string name, MATERIAL material) : this(name, material, 0, "нет данных", 0) { }
        public Toy(string name, MATERIAL material, double price, string producer, int validAge)
            : base(PRODUCT_TYPE.TOY, name, price, producer, validAge)
        {
            this.material = material;
        }

        //вывод данных для пользователя
        public override string ToString()
        {

            string materialDescr = "нет данных";
            switch (this.material)
            {
                case MATERIAL.PLASTIC: materialDescr = "пластик"; break;
                case MATERIAL.METAL: materialDescr = "метал"; break;
                case MATERIAL.WOOD: materialDescr = "дерево"; break;
            }

            return String.Format("{0}\nМатериал: {1}", base.ToString(), materialDescr);
        }
    }
}
