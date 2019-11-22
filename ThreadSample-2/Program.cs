using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSample_2
{
    class Program
    {

        private static volatile bool _cancel = false;

        static void Main(string[] args)
        {

            Thread t = new Thread(Speak);

            t.Start("Hello World!");

            
            Thread.Sleep(5000);

            
            _cancel = true;


            
            t.Join();
        }


        private static void Speak(object s)
        {

            while (!_cancel)
            {
                string say = s as string;
                Console.WriteLine(say);
            }

        }
    }
}
