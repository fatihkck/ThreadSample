using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _20_ProtectingSharedResources
{
    class Program
    {
        static int total = 0;
        static object _lock = new object();

        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            #region Single-Thread Sample
            //AddOneMillion();
            //AddOneMillion();
            //AddOneMillion();
            #endregion

            Thread t1 = new Thread(AddOneMillion);
            Thread t2 = new Thread(AddOneMillion);
            Thread t3 = new Thread(AddOneMillion);

            //t1.Start();
            //t1.Join();

            //t2.Start();
            //t2.Join();

            //t3.Start();
            //t3.Join();

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();


            Console.WriteLine("Total = {0}", total);

            stopwatch.Stop();

            Console.WriteLine(stopwatch.ElapsedTicks);

            Console.WriteLine("Main thread end");
            Console.Read();

        }


        #region Single-Thread Sample
        public static void AddOneMillion()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                //interlocked daha hızlıdır lock object'ten
                Interlocked.Increment(ref total);
                //lock (_lock)
                //{
                //    total++;
                //}

                //total++;
            }
        }
        #endregion
    }
}
