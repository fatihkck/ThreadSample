using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _26_AsyncAndParallelism
{
    class Program
    {
        static void Main(string[] args)
        {

            //Yeni thread oluşturmaz
            //Method1();
            //Method2();

            ////Yeni thread oluşur
            //Task.Run(() => Method1());
            //Task.Run(() => Method2());

            //Task.Factory.StartNew(Method1);
            //Task.Factory.StartNew(Method2);


            //ildasm den cl koduna bakarak nasıl çalıştığını anlarsın
            //StateMachines, the hidden receipe
            //https://channel9.msdn.com/Events/TechDays/Techdays-2014-the-Netherlands/Async-programming-deep-dive
            //Console.WriteLine("Code 1 " + Thread.CurrentThread.ManagedThreadId);
            //Console.WriteLine("Code 2 " + Thread.CurrentThread.ManagedThreadId);
            //SomeMethod();
            //Console.WriteLine("Code 7 " + Thread.CurrentThread.ManagedThreadId);
            //Console.WriteLine("Code 8 " + Thread.CurrentThread.ManagedThreadId);

            Task delay = asyncTask();
            syncCode();
            delay.Wait();


            Console.WriteLine("Done");
            Console.Read();
        }

        public static async void Method1Async()
        {
            await Task.Delay(5000);
            Console.WriteLine("Method 1 Async");
        }

        public static async void Method2Async()
        {
            await Task.Delay(5000);
            Console.WriteLine("Method 2 Async");
        }

        public static  void Method1()
        {
            Task.Delay(5000);
            Console.WriteLine("Method 1");
        }

        public static  void Method2()
        {
            Task.Delay(5000);

            Console.WriteLine("Method 2");
        }

        public static async Task<Customer> ProcessACustomer()
        {
            Customer cust = await GetCustomer();
            Thread.Sleep(2000);

            //...do something with the Customer object asynchronously
            return cust;
        }

        public static Task<Customer> GetCustomer()
        {
            
            Customer cust;
            cust = new Customer { Id = 1 };
            return Task.FromResult<Customer>(cust);
        }


        public static async void SomeMethod()
        {
            Console.WriteLine("Code 3 " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Code 4 " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(6000); //thise code run on a seperate
            Console.WriteLine("Code 5 " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Code 6 " + Thread.CurrentThread.ManagedThreadId);
        }

        static async Task asyncTask()
        {
            var sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("async1: Starting");
            Task delay = Task.Delay(5000);
            Console.WriteLine("async2: Running for {0} seconds", sw.Elapsed.TotalSeconds);
            await delay;
            Console.WriteLine("async3: Running for {0} seconds", sw.Elapsed.TotalSeconds);
            Console.WriteLine("async4: Done");
        }

        static void syncCode()
        {
            var sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("sync1: Starting");
            Thread.Sleep(5000);
            Console.WriteLine("sync2: Running for {0} seconds", sw.Elapsed.TotalSeconds);
            Console.WriteLine("sync3: Done");
        }

    }

    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
