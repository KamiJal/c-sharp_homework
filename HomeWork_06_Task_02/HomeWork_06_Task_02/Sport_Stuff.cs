using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_06_Task_02
{
    public class Sport_Stuff : Product
    {
        public Sport_Stuff() : this("нет данных") { }
        public Sport_Stuff(string name) : this(name, 0, "нет данных", 0) { }
        public Sport_Stuff(string name, double price, string producer, int validAge)
            : base(PRODUCT_TYPE.SPORT_STUFF, name, price, producer, validAge)
        {

        }

    }
}
