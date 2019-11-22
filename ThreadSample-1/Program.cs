using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSample_1
{
    class Program
    {
        static void Main(string[] args)
        {

            ///program çlışınca single thread(main thread) oluşur.
            ///yeni bir thread başlatmak için thread class'ından yeni bir örnek almak gerekir. Bunuda Thread.Start metotu sağlar.
            ///

            Thread t = new Thread(() => Console.WriteLine("Test"));
            t.Start();

            Thread thread = new Thread(DoSomething);
            thread.Name = "my first doSomething";
            thread.Priority = ThreadPriority.BelowNormal;

            Thread thread1 = new Thread(DoSomethingWithParam);
            thread1.Name = "my second doSomething";
            thread1.IsBackground = true;


            //thread başlar
            thread.Start();
            thread1.Start(1);

            for(int i = 0; i < 4; i++)
            {
                Thread thread2 = new Thread(DoSomething);
                thread2.Name = "my doSomething " + i;

                thread2.Start();
            }



            //thread parallel çalışır iken başka operasyona geçebilirsin burada

            Console.WriteLine("Done");
            Console.ReadLine();


        }

        private static void DoSomething()
        {
            
            Console.WriteLine("Caling DoSomething() method...");
            Thread.Sleep(3000);
            Console.WriteLine("Method end");

        }

        private static void DoSomethingWithParam(object a)
        {
            Console.WriteLine("Caling DoSomething() method... {0}", a);
            Thread.Sleep(3000);
            Console.WriteLine("Method end");

        }
    }
}
