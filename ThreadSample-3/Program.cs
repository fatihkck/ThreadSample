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


            Thread t = new Thread(DoSomeThing);
            Thread t1 = new Thread(DoSomeThing);


            t.Start();
            t.Join();

            t1.Start();
            

            Console.WriteLine("Press Enter to terminate!");
            Console.ReadLine();

        }


        public static void DoSomeThing()
        {
            Console.WriteLine("Test");

            Thread.Sleep(2000);
        }
    }
}
