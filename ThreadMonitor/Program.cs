using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSynchronizationRaceCondition
{
    class Program
    {

        private static int sum;
        private static object _lock = new object();
        static void Main(string[] args)
        {

            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 10000000; i++)
                {
                    Monitor.Enter(_lock);


                    try
                    {
                        //increment sum value
                        sum++;
                    }
                    finally
                    {
                        //release lock ownership
                        Monitor.Exit(_lock);
                    }
                }
            }
            );


            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 10000000; i++)
                {
                    Monitor.Enter(_lock);
                    
                    try
                    {
                        //increment sum value
                        sum++;
                    }
                    finally
                    {
                        //release lock ownership
                        Monitor.Exit(_lock);
                    }
                }
            }
            );


            t1.Start();
            t2.Start();


            t1.Join();
            t2.Join();


            Console.WriteLine("sum :" + sum);

            Console.WriteLine("done");

            Console.Read();



        }
    }
}
