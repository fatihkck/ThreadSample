using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13_NonResponsiveApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            label2.Text = Fibo(textBox1.Text).ToString();
            stopWatch.Stop();
            label1.Text = (stopWatch.ElapsedMilliseconds / 1000).ToString();
        }


        private ulong Fibo(string nthValue)
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

        private void button2_Click(object sender, EventArgs e)
        {
            //var task = new Task(() =>
            //{
            //    var stopWatch = new Stopwatch();
            //    stopWatch.Start();
            //    label2.Text = Fibo(textBox1.Text).ToString();
            //    stopWatch.Stop();
            //    label1.Text = (stopWatch.ElapsedMilliseconds / 1000).ToString();
            //});

            ///WPF and most Windows UI frameworks have something called “Thread affinity”. This means you can’t change UI stuff on any thread that isn’t the main UI thread.
            //task.Start();//not working


            //// once again lock up.Because, we’re running the task on the same UI thread, consuming the same UI thread’s execution cycle until the task execution is done, which is essentially the entire time which locks up the user interface and thus we’re back to where we started.
            //task.Start(TaskScheduler.FromCurrentSynchronizationContext());
            ////TaskScheduler.FromCurrentSynchronizationContext() To solve this problem one thing we can do is we can specify the .NET to run this particular task in UI thread which is our current thread instead of running into a separate thread by using the task scheduler parameter in task.Start() method like this,

            ///Correct solution
            ///
            #region Correct way one
            //Stopwatch stopWatch = new Stopwatch();
            //string result = "";

            //var task = new Task(() =>
            //{
            //    stopWatch.Start();
            //    result = Fibo(textBox1.Text).ToString();
            //});

            //task.ContinueWith((previousTask) =>
            //{
            //    label2.Text = result;
            //    stopWatch.Stop();
            //    label1.Text = (stopWatch.ElapsedMilliseconds / 1000).ToString();
            //    stopWatch.Reset();
            //},
            //TaskScheduler.FromCurrentSynchronizationContext()
            //);

            //task.Start();
            #endregion

            #region Correct way second
            Stopwatch stopWatch = new Stopwatch();

            Task<string> task = Task.Run(() =>
            {
                stopWatch.Start();
                var result = Fibo(textBox1.Text).ToString();
                return result;
            });


            task.ContinueWith((previousTask) =>
            {
                label2.Text = previousTask.Result;
                stopWatch.Stop();
                label1.Text = (stopWatch.ElapsedMilliseconds / 1000).ToString();
                stopWatch.Reset();
            },
            TaskScheduler.FromCurrentSynchronizationContext()
            );

            //var completedTask = task.ContinueWith((i) =>
            //{

            //    MessageBox.Show("done");

            //}, TaskContinuationOptions.OnlyOnRanToCompletion);

            #endregion
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
        }
    }
}
