using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskWithReturn
{
    class Program
    {
        static void Main(string[] args)
        {

            Task<int> t = Task.Run(() =>
            {

                int sum = 0;
                for (int i = 0; i < 1000; i++)
                {
                    sum++;

                }

                return sum;
            });



            //equivalent to calling Join and wait
            Console.WriteLine(t.Result);


            Task t1 = new Task(() =>
            {

                for (int i = 0; i < 1000; i++)
                {
                    Console.WriteLine(i);
                }
            });
            t1.Start();

      



            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
