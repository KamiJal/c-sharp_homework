using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_07_Task_01
{
    public class Tank
    {
        private static Random rnd = new Random();
    
        public string name { private set; get; }
        public int ammo { private set; get; }
        public int armor { private set; get; }
        public int maneuverability { private set; get; }

        public Tank(string name)
        {
            this.name = name;
            this.ammo = rnd.Next(0, 100);
            this.armor = rnd.Next(0, 100);
            this.maneuverability = rnd.Next(0, 100);
        }

        //перегрузка оператора *
        public static bool operator *(Tank left, Tank right)
        {
            int leftWins = 0;
            int rightWins = 0;


            if (left.ammo > right.ammo) leftWins++;
            else rightWins++;

            if (left.ammo > right.ammo) leftWins++;
            else rightWins++;

            if (left.ammo > right.ammo) leftWins++;
            else rightWins++;

            return leftWins > rightWins;
        }

        public override string ToString()
        {
            return String.Format("Танк: {0}\nБоекомплект: {1}, бронирование: {2}, маневренность: {3}", this.name, this.ammo, this.armor, this.maneuverability);
        }

    }
}
