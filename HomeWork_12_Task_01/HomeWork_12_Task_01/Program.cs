using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_12_Task_01
{
    partial class Program
    {
        private static Random rnd = new Random();
        private static string divider = "\n-----------------------------------------------------------------------------------";

        static void Main(string[] args)
        {

            Program program = new Program();

            program.Task_01();
            program.Task_02();
            program.Task_03();
            program.Task_04();
            program.Task_05();

            Console.ReadKey();
        }
    }
}
