using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _27_ThreadSleepTaskDelay
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void PutThreadSleep()
        {
            Thread.Sleep(5000);
        }

        CancellationTokenSource tokenSource = new CancellationTokenSource();

        async Task PutTaskDelay()
        {
            //Delay logic akışı bekletir asenkrondur. Mevcut threadi blocklamaz. İptal edilebilinir.
            try
            {
                
                await Task.Delay(5000, tokenSource.Token);
            }
            catch (TaskCanceledException ex)
            {

            }
            catch (Exception ex)
            {

            }
            tokenSource.Dispose();
            tokenSource = new CancellationTokenSource();
        }

        private void ThreadSleep_Click(object sender, EventArgs e)
        {
            PutThreadSleep();
            MessageBox.Show("I am back");
        }

        private async void TaskDelay_Click(object sender, EventArgs e)
        {
            await PutTaskDelay();
            MessageBox.Show("I am back");
        }

        private void CancelTaskDelay_Click(object sender, EventArgs e)
        {
     

            tokenSource.Cancel();
        }

    }
}
