using System;
using System.Threading.Tasks;

namespace _28_AsyncMethod1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                // Start computation.
                Example();
                // Handle user input.
                string result = Console.ReadLine();
                Console.WriteLine("You typed: " + result);
            }
        }


        static async void Example()
        {
            // This method runs asynchronously.
            int t = await Task.Run(() => Allocate());
            Console.WriteLine("Compute: " + t);
        }

        static int Allocate()
        {

            // Compute total count of digits in strings.
            int size = 0;
            for (int z = 0; z < 100; z++)
            {
                for (int i = 0; i < 1000000; i++)
                {
                    string value = i.ToString();
                    size += value.Length;
                }
            }
            return size;
        }
    }
}
