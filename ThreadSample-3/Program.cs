using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSample_3
{
    class Program
    {
        static void Main(string[] args)
        {


            Thread t1 = new Thread(Thread1Funciton);
            t1.Start();

            Thread t2 = new Thread(Thread2Funciton);
            t2.Start();

            //Belirtilen sürede bitmezse t1 therad beklemeden devam eder.
            //t1.Join(1000);

            if (t1.Join(1000))
            {
                Console.WriteLine("Thread1Funciton completed");
            }
            else
            {
                Console.WriteLine("Thread1Funciton has not completed 1 second");

            }

            //Console.WriteLine("Thread1Funciton completed");

            t2.Join();
            Console.WriteLine("Thread2Funciton completed");


            //if (t1.IsAlive)
            //{
            //    Console.WriteLine("Thread1Funciton is still doing it's work");
            //}
            //else
            //{
            //    Console.WriteLine("Thread1Funciton completed");
            //}

            while (t1.IsAlive)
            {
                Console.WriteLine("Thread1Funciton is still doing it's work");
                Thread.Sleep(500);
            }

            if (!t1.IsAlive)
            {
                Console.WriteLine("Thread1Funciton completed");
            }

            Console.WriteLine("Main Complate");
            Console.ReadLine();

        }


        public static void Thread1Funciton()
        {
            Console.WriteLine("Thread1Funciton started");
            Thread.Sleep(3000);
            Console.WriteLine("Thread1Funciton is about to return");
        }

        public static void Thread2Funciton()
        {
            Console.WriteLine("Thread2Funciton started");
        }

    }
}
