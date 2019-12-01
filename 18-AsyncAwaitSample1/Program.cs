using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _18_AsyncAwaitSample1
{
    class Program
    {
        static void Main(string[] args)
        {

            //CallMethodWithThread();
            CallMethodWithTask();

            Console.WriteLine("Main Thread End");

            Console.Read();
        }


        public static void  CallMethodWithThread()
        {

            //çağırdın metotdan dönüş değeri alamazsın
            //parametreli bir metot ise object parametresi göndermelisin
            Thread t1 = new Thread(MetotForThread);
            t1.Start("1");
        }

       public static void CallMethodWithTask()
        {
            Task<ulong> t1 = Task.Run(() =>
            {
                return FiboForTask("1000000000");

            });
            
            Console.WriteLine(t1.Result);
            Console.WriteLine("Task end");
           
        }


   
        public static void MetotForThread(object param)
        {
            Thread.Sleep(2000);
            Console.WriteLine("Thread metot run {0}", param);
        }

        public static ulong FiboForTask(string nthValue)
        {
            try
            {
                ulong x = 0, y = 1, z = 0, nth, i;
                nth = Convert.ToUInt64(nthValue);
                for (i = 1; i <= nth; i++)
                {
                    z = x + y;
                    x = y;
                    y = z;
                }

                return z;
            }
            catch { }

            return 0;
        }

    }
}
