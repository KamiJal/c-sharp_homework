using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace HomeWork_07_Task_02
{
    public class Monitor
    {
        public string producer { private set; get; }        //производитель
        public string name { private set; get; }            //название
        public double diagonal { private set; get; }        //диагональ
        public int price { private set; get; }              //цена

        public Monitor(string producer, string name, double diagonal, int price)
        {
            this.producer = producer;
            this.name = name;
            this.diagonal = diagonal;
            this.price = price;
        }

        //сравниваем 2 монитора по диагонали
        public static bool operator ==(Monitor m1, Monitor m2)
        {
            return m1.diagonal == m2.diagonal;
        }     
        public static bool operator !=(Monitor m1, Monitor m2)
        {
            return m1.diagonal != m2.diagonal;
        }

        //полное сравнение 2 мониторов на соответствие 
        //используем для этого рефлексию и сравнение хешей
        public override bool Equals(object obj)
        {

            //проверка на null, на соответствие классов и на хэшкоды
            if (obj == null || this.GetHashCode() != obj.GetHashCode() || obj.GetType() != this.GetType())
                return false;
            //создаем временный монитор
            Monitor temp = (Monitor)obj;
            //если все поля равны друг другу, то объекты равны
            if (this.name.Equals(temp.name) && this.producer.Equals(temp.producer) && this.diagonal == temp.diagonal && this.price == temp.price)
                return true;

            return false;
        }
    }
}
