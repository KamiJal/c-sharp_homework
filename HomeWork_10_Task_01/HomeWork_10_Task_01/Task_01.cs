using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace HomeWork_10_Task_01
{
    partial class Program
    {
        public void Task_01()
        {
            try
            {
                WebClient client = new WebClient();
                string URL = "http:\\871aijwieuoiqkweq981";
                client.DownloadData(URL);
            }
            catch (ArgumentException e) { Console.WriteLine(e.Message); }
            catch (WebException e) { Console.WriteLine(e.Message); }
        }

    }
}
