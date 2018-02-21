using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_07_Task_04
{
    //конвертер
    public class Converter
    {

        public static double KZTtoUSD (Money source, double rate)
        {
            if (source.type == MONEY_TYPE.USD)
                return source.value * rate;

            return source.value / rate;
        }
    }
}
