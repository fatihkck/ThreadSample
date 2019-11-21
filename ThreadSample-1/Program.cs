using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSample_1
{
    class Program
    {
        static void Main(string[] args)
        {

            ///program çlışınca single thread(main thread) oluşur.
            ///yeni bir thread başlatmak için thread class'ından yeni bir örnek almak gerekir. Bunuda Thread.Start metotu sağlar.
            


        }

        private static void DoSomething()
        {
            Console.WriteLine("Caling DoSomething() method...");
        }
    }
}
