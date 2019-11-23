using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskSample
{
    class Program
    {
        static void Main(string[] args)
        {

            Task t = new Task(() =>
            {
                for(int i = 0; i < 100; i++)
                {
                    var threadId = Thread.CurrentThread.ManagedThreadId;
                    Console.WriteLine("{0} - Task loop current thread id: {1}", i,threadId);
                    


                }
            });
        
            t.Start();


    


            for (int i = 0; i < 100; i++)
            {
                //print main thread id
                var threadId = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine("{0} - Main loop current thread id: {1}", i, threadId);
            }


            //t işlemini bitirene kadar kadar gelecek işlemleri bekletir
            //equivalent to calling Join
            //wait kullanıldığında main thread t task kı tamamlana kadar durur.
            t.Wait();






            Console.WriteLine("for blokları paralel olarak çalışır");


            Console.ReadLine();
        }
    }
}
