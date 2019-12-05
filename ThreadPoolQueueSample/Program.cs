using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolQueueSample
{
    class Program
    {
        static void Main(string[] args)
        {

            ///Thread işi bittik ten sonra kapanır. Ancak birden fazla thread oluşturup kapama aşamasında
            ///durmadan thread açıp kapatmak maliyetli olabilir.
            ///Bunun için threadpool yapısı kullanılır. Kullanılacak threadler burada toplanır. 
            ///İş parçacığı havuzunda iş olduğu sürece threadpool kendini kapamaz. 
            //WaitCallback boşta thread olanakadar bekler

            ThreadPool.SetMinThreads(1, 10);//SetMintThreads başlangıç için minimum thread talep eder
            ThreadPool.QueueUserWorkItem(DoSomething);
            ThreadPool.QueueUserWorkItem(DoSomething);
            ThreadPool.QueueUserWorkItem(DoSomething);

            Console.WriteLine("Thread Pool Performans Benchmark => ThreadPool Faster");

            Stopwatch mywatch = new Stopwatch();

            Console.WriteLine("Thread Pool Execution");

            mywatch.Start();
            ProcessWithThreadPoolMethod();
            mywatch.Stop();

            Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + mywatch.ElapsedTicks.ToString());
            mywatch.Reset();


            Console.WriteLine("Thread Execution");

            mywatch.Start();
            ProcessWithThreadMethod();
            mywatch.Stop();

            Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + mywatch.ElapsedTicks.ToString());

            Console.WriteLine("done");
            Console.ReadLine();

        }

        public static void DoSomething(object state)
        {
            Console.WriteLine("Running DoSomething {0}", state);
            Thread.Sleep(3000);
            
            Console.WriteLine("Done method");

        }

        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i <= 10; i++)
            {

                
                ThreadPool.QueueUserWorkItem(new WaitCallback(Process));
            }
        }

        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread obj = new Thread(Process);
                obj.Start();
            }
        }

        static void Process(object callback)
        {

        }

    }
}
