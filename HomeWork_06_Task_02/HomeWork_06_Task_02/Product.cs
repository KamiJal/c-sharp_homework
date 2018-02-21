using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_06_Task_02
{
    public abstract class Product
    {
        public PRODUCT_TYPE type { private set; get; }      //тип продукта
        public string name { private set; get; }            //название
        public double price { private set; get; }           //стоимость
        public string producer { private set; get; }        //производитель
        public int validAge { private set; get; }           //ограничение по возрасту

        protected Product(PRODUCT_TYPE type, string name, double price, string producer, int validAge)
        {
            this.type = type;
            this.name = name;
            this.price = price;
            this.producer = producer;
            this.validAge = validAge;
        }

        //вывод данных для пользователя
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string typeDescr = "нет данных";

            switch (type)
            {
                case PRODUCT_TYPE.BOOK: typeDescr = "КНИГА"; break;
                case PRODUCT_TYPE.TOY: typeDescr = "ИГРУШКА"; break;
                case PRODUCT_TYPE.SPORT_STUFF: typeDescr = "СПОРТ. ИНВЕНТАРЬ"; break;
            }

            sb.Append(String.Format("ТИП: {0}\n", typeDescr));            
            sb.Append(String.Format("Название: {0}, производитель/издатель: {1}\nСтоимость: {2:N0} тенге\n", this.name, this.producer, this.price));
            sb.Append(String.Format("Ограничение по возрасту: {0}+", this.validAge));

            return sb.ToString();
        }


    }
}
