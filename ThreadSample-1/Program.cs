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

            Thread thread = new Thread(DoSomething);
            Thread thread1 = new Thread(DoSomething);

            
            //thread başlar
            thread.Start();
            thread1.Start();



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
    }
}
