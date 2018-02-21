using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_07_Task_04
{
    public class Money
    {
        public MONEY_TYPE type { private set; get; }
        public double value { private set; get; }

        public Money(MONEY_TYPE type, double value)
        {
            this.type = type;
            this.value = value;
        }

        public static bool operator ==(Money m1, Money m2)
        {

            return m1.value == m2.value;
        }

        public static bool operator !=(Money m1, Money m2)
        {
            return !(m1 == m2);
        }
    }
}
