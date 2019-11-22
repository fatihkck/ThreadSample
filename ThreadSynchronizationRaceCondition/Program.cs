using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSynchronizationRaceCondition
{
    class Program
    {

        private static int sum;
        static void Main(string[] args)
        {

            Thread t1 = new Thread(() =>
                {
                    for (int i = 0; i < 10000000; i++)
                    {
                        sum++;
                    }
                }
            );


            Thread t2 = new Thread(() =>
                {
                    for (int i = 0; i < 10000000; i++)
                    {
                        sum++;
                    }
                }
            );


            t1.Start();
            t2.Start();


            t1.Join();
            t2.Join();


            Console.WriteLine("sum :" + sum);

            Console.WriteLine("her çalıştırmada toplam farklı sonuç çıkıyor");

            Console.Read();



        }
    }
}
