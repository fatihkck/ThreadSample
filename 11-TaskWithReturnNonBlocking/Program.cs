using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_TaskWithReturnNonBlocking
{
    class Program
    {
        static void Main(string[] args)
        {

            Task<int> t = Task.Run(() =>
            {
                
                return 32;
            });


            Task<int> t1 = Task.Run(() =>
            {

                int sum = 0;
                for (int i = 0; i < 1000; i++)
                {
                    sum++;

                }

                return sum;
            });


            t.ContinueWith((i) =>
            {
                Console.WriteLine(i.Result);
            });

            t1.ContinueWith((i) =>
            {
                Console.WriteLine(i.Result);
            });

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            

           

            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
