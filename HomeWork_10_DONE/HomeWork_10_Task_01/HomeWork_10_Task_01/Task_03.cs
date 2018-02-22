using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_10_Task_01
{
    partial class Program
    {
        public void Task_03()
        {
            try
            {
                A();
            }
            catch (ArgumentNullException e) {
                Console.WriteLine("СООБЩЕНИЕ: {0}\nОбработано в Task_03()\n", e.Message);
            }
        }

        public void A() {
            B();
        }

        public void B()
        {
            C();
        }

        public void C()
        {
            try
            {
                D();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("СООБЩЕНИЕ: {0}\nОбработано в C()\n", e.Message);
                Console.WriteLine("Сгенерировано исключение ArgumentNullException в С()");
                throw new ArgumentNullException();
            }
        }

        public void D()
        {
            E();
        }

        public void E()
        {
            Console.WriteLine("Сгенерировано исключение ArgumentException в E()");
            throw new ArgumentException();
        }



    }
}
