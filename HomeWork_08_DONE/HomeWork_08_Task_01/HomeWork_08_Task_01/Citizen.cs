using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUMAN
{
    public class Citizen : Human
    {
        //физическое или юридическое лицо
        public HUMAN_CATEGORY Category { private set; get; }

        //локация: область, район, город
        public LOCATION Location { private set; get; }

        //ИИН
        public string IIN { private set; get; }

        //инвалидность
        public DISABLED Disabled { private set; get; }

        //работоспособность - зависит от инвалидности
        public WORKING_CAPACITY WorkingCapacity { private set; get; }

        //дети
        public List<Human> children { private set; get; }

        //конструктор
        public Citizen(HUMAN_CATEGORY Category, LOCATION Location, string FirstName, string LastName, DateTime DateOfBirth, SEX Sex, string IIN, DISABLED Disabled) :
            base(FirstName, LastName, DateOfBirth, Sex)
        {
            this.Category = Category;
            this.Location = Location;
            this.IIN = IIN;
            this.Disabled = Disabled;

            if ((int)Disabled == 3)
                this.WorkingCapacity = WORKING_CAPACITY.INCAPABLE;
            else
                this.WorkingCapacity = WORKING_CAPACITY.CAPABLE;

            this.children = new List<Human>();
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(String.Format("ФИО: {0}, пол: {1}, дата рождения: {2}\n", this.GetFullName(), Sex == SEX.MALE ? "мужской" : "женский", DateOfBirth.ToString("dd.MM.yyyy")));

            string catDescr = "не указано";

            switch (Category)
            {
                case HUMAN_CATEGORY.INDIVIDUAL: catDescr = "физическое лицо"; break;
                case HUMAN_CATEGORY.ENTITY: catDescr = "юридическое лицо"; break;
            }

            string locDescr = "не указано";

            switch (Location)
            {
                case LOCATION.REGION: locDescr = "область"; break;
                case LOCATION.CITY: locDescr = "город"; break;
                case LOCATION.DISTRICT: locDescr = "район"; break;
            }

            sb.Append(String.Format("Категория: {0}, агломерация: {1}, ИИН: {2}\n", catDescr, locDescr, this.IIN));

            string disDescr = "нет";

            switch (Disabled)
            {
                case DISABLED.CATEGORY_01: disDescr = "категория 1"; break;
                case DISABLED.CATEGORY_02: disDescr = "категория 2"; break;
                case DISABLED.CATEGORY_03: disDescr = "категория 3"; break;
            }

            string workCapDescr = WorkingCapacity == WORKING_CAPACITY.CAPABLE ? "дееспособный" : "недееспособный";

            sb.Append(String.Format("Инвалидность: {0}, работоспособность: {1}, дети: {2}\n", disDescr, workCapDescr, children.Count == 0 ? "нет" : "есть"));

            return sb.ToString();
        }
    }
}
