using System;
using System.Collections.Generic;
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
            ThreadPool.SetMinThreads(1, 10);
            ThreadPool.QueueUserWorkItem(DoSomething);
            ThreadPool.QueueUserWorkItem(DoSomething);
            ThreadPool.QueueUserWorkItem(DoSomething);


            Console.WriteLine("done");
            Console.ReadLine();

        }

        public static void DoSomething(object state)
        {
            Console.WriteLine("Running DoSomething {0}", state);
            Thread.Sleep(3000);
            
            Console.WriteLine("Done method");

        }
    }
}
