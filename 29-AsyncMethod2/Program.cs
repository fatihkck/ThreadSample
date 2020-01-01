using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _29_AsyncMethod2
{
    class Program
    {
        static void Main(string[] args)
        {



            // Call async method 10 times.
            for (int i = 0; i < 30; i++)
            {
                Run2Methods(i);
            }
            // The calls are all asynchronous, so they can end at any time.

            Console.WriteLine("done");
            Console.ReadLine();
        }

        static async void Run2Methods(int count)
        {
            // Run a Task that calls a method, then calls another method with ContinueWith.
            int result = await Task.Run(() => GetSum(count))
                .ContinueWith(task => MultiplyNegative1(task));
            
            Console.WriteLine("Run2Methods result: " + result);
        }

        static int GetSum(int count)
        {
            Thread.CurrentThread.Name = "name" + count;
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            //Thread.Sleep(1000);
            // This method is called first, and returns an int.
            int sum = 0;
            for (int z = 0; z < count; z++)
            {
                sum += (int)Math.Pow(z, 2);
            }
            return sum;
        }

        static int MultiplyNegative1(Task<int> task)
        {
            // This method is called second, and returns a negative int.
            return task.Result * -1;
        }


        async static void BackgroundMethod()
        {
            // Use a local function.
            void InnerMethod()
            {
                while (true)
                {
                    System.Threading.Thread.Sleep(150);
                    Console.WriteLine("::Background::");
                }
            }
            // Create a new Task and start it.
            // ... Call the local function.
            var task = new Task(() => InnerMethod());
            task.Start();
            await task;
        }
    }
}
