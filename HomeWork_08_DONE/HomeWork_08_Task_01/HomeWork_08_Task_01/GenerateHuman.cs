using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorName;
using System.Text.RegularExpressions;

namespace HUMAN
{
    public class HumanGenerator
    {
        private static Random rnd = new Random();

        public Human GenerateDefault(SEX Sex)
        {
            Generator g = new Generator();
            StringBuilder sb = new StringBuilder();


            //генерируем имя
            string name = "";

            if(Sex == SEX.MALE)
                name = g.GenerateDefault(Gender.man);

            if (Sex == SEX.FEMALE)
                name = g.GenerateDefault(Gender.woman);

            name = name.Substring(25);
            name = name.Substring(0, name.IndexOf('<'));
            name = Regex.Replace(name, @"\s+", " ");
            name.Trim();

            string FirstName = name.Split(' ')[0];
            string LastName = name.Split(' ')[1];

            
            //генерируем дату рождения
            DateTime DateOfBirth = DateTime.Now;
            bool success = false;
            

            while (!success){
                sb.Append(String.Format("{0}-{1}-{2}", rnd.Next(1930, DateTime.Now.Year), rnd.Next(1, 12), rnd.Next(1, 31)));
                success = DateTime.TryParse(sb.ToString(), out DateOfBirth);
            }

            //генерируем поля ENUM
            HUMAN_CATEGORY Category = (HUMAN_CATEGORY)rnd.Next(1, 2);
            LOCATION Location = (LOCATION)rnd.Next(1, 3);
            DISABLED Disabled = (DISABLED)rnd.Next(0, 3);

            //генерируем ИИН
            sb.Clear();
            sb.Append(String.Format("{0}{1}{2:00000}", DateOfBirth.ToString("yyMMdd"), Sex == SEX.MALE ? 3 : 4, rnd.Next(1, 99999)));
            string IIN = sb.ToString();

            return new Citizen(Category, Location, FirstName, LastName, DateOfBirth, Sex, IIN, Disabled);
        }




    }
}
