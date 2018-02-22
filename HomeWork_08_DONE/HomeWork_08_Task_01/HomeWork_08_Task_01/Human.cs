using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUMAN
{
    public abstract class Human
    {
        //имя
        protected string FirstName { private set; get; }

        //фамилия  
        protected string LastName { private set; get; }

        //дата рождения
        protected DateTime DateOfBirth { private set; get; }                
        
        //пол
        protected SEX Sex { private set; get; }

        //возвращает полное имя
        protected string GetFullName()
        {
            return LastName + " " + FirstName;
        }

        //конструктор
        protected Human(string FirstName, string LastName, DateTime DateOfBirth, SEX Sex)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Sex = Sex;
        }

        public override abstract string ToString();

    }
}
