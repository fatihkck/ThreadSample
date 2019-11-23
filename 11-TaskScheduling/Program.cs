using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_TaskScheduling
{
    class Program
    {

        static void Main(string[] args)
        {


            Task<int> t = Task.Run(() =>
            {
                return 32;
            }).ContinueWith((i) =>
            {
                

                return i.Result;
            });


            t.ContinueWith((i) =>
            {
                Console.WriteLine("Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);


            t.ContinueWith((i) =>
            {
                Console.WriteLine("Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);


            var completedTask = t.ContinueWith((i) =>
            {
                Console.WriteLine(i.Result);
                Console.WriteLine("Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            Console.WriteLine("In desktop applications like Windows Forms and WPF, we can use this feature of the task to create a very responsive application that doesn’t block the UI thread.");
            Console.ReadLine();
        }

    }
}
