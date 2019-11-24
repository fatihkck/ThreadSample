using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _16_ParallelClass
{
    class Program
    {
        static void Main(string[] args)
        {

            Parallel.For(0, 10, i =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("one {0}",i);
            });
            var numbers = Enumerable.Range(0, 10);
            Parallel.ForEach(numbers, i =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("two {0}", i);
            });

            

            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
