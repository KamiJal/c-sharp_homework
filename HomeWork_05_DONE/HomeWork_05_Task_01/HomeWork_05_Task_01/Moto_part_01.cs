using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_05_Task_01
{
    //первая часть класса Мoto
    public partial class Moto
    {
        public static int motoCount { private set;  get; }      //количество мотоциклов в программе
        public static double maxPrice { private set;  get; }    //общая цена всех мотоциклов

        public MOTOMAKER maker { private set;  get; }           //производитель
        public string model { private set;  get; }              //модель
        public double ccVolume { private set;  get; }           //объем двигателя
        public int maxSpeed { private set;  get; }              //максимальная скорость
        public int horsePower {private set;  get; }             //лошадиные силы
        public double price {private set;  get; }               //стоимость

        static Moto()
        {
            motoCount = 0;
            maxPrice = 0;
        }

        public Moto() : this(MOTOMAKER.NOT_DEFINED, null) { }
        public Moto(MOTOMAKER maker, string model) : this(maker, model, 0) { }
        public Moto(MOTOMAKER maker, string model, double ccVolume) : this(maker, model, ccVolume, 0) { }
        public Moto(MOTOMAKER maker, string model, double ccVolume, double price) : this(maker, model, ccVolume, 0, 0, price) { }
        public Moto(MOTOMAKER maker, string model, double ccVolume, int maxSpeed, int horsePower, double price)
        {
            this.maker = maker;
            this.model = model;
            this.ccVolume = ccVolume;
            this.maxSpeed = maxSpeed;
            this.horsePower = horsePower;
            this.price = price;
            motoCount++;
            maxPrice += price;
        }

        //вывод отдель производителя и модели
        public string getFullName()
        {
            return maker.ToString() + " " + model;
        }

        //расчет мощности
        public double getKwt()
        {
            return this.horsePower * 0.7457;
        }

        //стоимость в USD
        public double priceInUSD()
        {
            return this.price / 320.7;
        }



    }
}
