using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_06_Task_02
{
    public class Book : Product
    {
        public string author { private set; get; }      //автор

        public Book() : this("нет данных", "нет данных") { }
        public Book(string name, string author) : this(name, author, 0, "нет данных", 0) { }
        public Book(string name, string author, double price, string producer, int validAge)
            : base(PRODUCT_TYPE.BOOK, name, price, producer, validAge)
        {
            this.author = author;
        }

        //вывод данных для пользователя
        public override string ToString()
        {
            return String.Format("{1}\nАвтор: {0}", this.author, base.ToString());
        }
    }
}
