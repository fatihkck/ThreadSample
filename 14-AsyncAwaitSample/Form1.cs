using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14_AsyncAwaitSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var url = textBox1.Text;

            var isValidUrl = Uri.TryCreate(url, UriKind.Absolute,out _);

            if (!isValidUrl)
            {
                textBox2.Text = "Not valid url";
                return;
            }

            var currencContext = TaskScheduler.FromCurrentSynchronizationContext();

            var httpClient = new HttpClient();

            var responseTask = httpClient.GetAsync(url);

            ///callback
            responseTask.ContinueWith(r =>
            {

                try
                {
                    var response = r.Result;
                    response.EnsureSuccessStatusCode();

                    var dataTask = response.Content.ReadAsStringAsync();

                    ///callback hell
                    dataTask.ContinueWith(d =>
                    {
                        textBox2.Text = d.Result;

                    }, currencContext);
                    

                }
                catch (Exception ex)
                {

                    textBox2.Text = ex.Message;
                }

            });


        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var url = textBox1.Text;

            var isValidUrl = Uri.TryCreate(url, UriKind.Absolute, out _);

            if (!isValidUrl)
            {
                textBox2.Text = "Not valid url";
                return;
            }

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);

            try
            {
                response.EnsureSuccessStatusCode();

                var data = await response.Content.ReadAsStringAsync();
                textBox2.Text = data;

            }
            catch (Exception ex)
            {
                textBox2.Text = ex.Message;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var url = textBox1.Text;

            var isValidUrl = Uri.TryCreate(url, UriKind.Absolute, out _);

            if (!isValidUrl)
            {
                textBox2.Text = "Not valid url";
                return;
            }


            Task<string> task = Task.Run(() =>
            {
                var httpClient = new HttpClient();
                var result = httpClient.GetAsync(url).Result.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
                return result;
            });


            task.ContinueWith((previousTask) =>
            {
                textBox2.Text = previousTask.Result;
            },
            TaskScheduler.FromCurrentSynchronizationContext()
            );

        }
    }
}
