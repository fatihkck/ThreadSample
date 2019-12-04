using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _24_TaksPrallelLibrary
{
    class Program
    {
        static void Main(string[] args)
        {

            //Thread o1 = new Thread(RunMillionIterations);
            //o1.Start();

            //birden fazla threade hesaplama yapıp çıktıyı senkronize eder verir
            Parallel.For(0, 1000000, x => RunMillionIterations());


            Console.WriteLine("Done");
            Console.Read();
        }

        public static void RunMillionIterations()
        {
            string x = "";
            for (int i = 0; i < 1000000; i++)
            {
                x = x + "fatih";
            }
        }
    }
}
