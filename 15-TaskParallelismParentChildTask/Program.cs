using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _15_TaskParallelismParentChildTask
{
    class Program
    {
        static void Main(string[] args)
        {

            //Task<int[]> parent = new Task<int[]>(() =>
            //{
            //    var results = new int[3];
            //    new Task(() => {
            //        Thread.Sleep(3000);
            //        results[0] = 0;
            //    },
            //    TaskCreationOptions.AttachedToParent).Start();
            //    new Task(() => results[1] = 1,
            //    TaskCreationOptions.AttachedToParent).Start();
            //    new Task(() => results[2] = 2,
            //    TaskCreationOptions.AttachedToParent).Start();
            //    return results;
            //});
            //parent.Start();
            //var finalTask = parent.ContinueWith(
            //parentTask => {
            //    foreach (int i in parentTask.Result)
            //        Console.WriteLine(i);
            //});
            //finalTask.Wait();
            //Console.ReadLine();


            ////Taskfactory süreci kolaylaştırır

            //Task<int[]> parent1 = new Task<int[]>(() =>
            //{
            //    var results = new int[3];
            //    TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent,
            //    TaskContinuationOptions.ExecuteSynchronously);
            //    tf.StartNew(() => {
            //        Thread.Sleep(3000);
            //        results[0] = 0;
            //    });
            //    tf.StartNew(() => results[1] = 1);
            //    tf.StartNew(() => results[2] = 2);
            //    return results;
            //});
            //parent1.Start();
            //var finalTask1 = parent1.ContinueWith(
            //parentTask => {
            //    foreach (int i in parentTask.Result)
            //        Console.WriteLine(i);
            //});
            //finalTask1.Wait();
            //Console.ReadLine();

      
            Console.ReadLine();
        }
    }
}
