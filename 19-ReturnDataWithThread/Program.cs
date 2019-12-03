using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _19_ReturnDataWithThread
{
    public delegate void SumOfNumbersCallback(int sumOfNumber);

    class Program
    {
        static void Main(string[] args)
        {
            //Thread ile Parametre ve değer dönderme örneği

            Console.WriteLine("Lütfen numara giriniz");
            int target = Convert.ToInt32(Console.ReadLine());


            SumOfNumbersCallback callBack = new SumOfNumbersCallback(PrintSumOfNumber);

            CalculateNumber calculateNum = new CalculateNumber(target, callBack);

            Thread t1 = new Thread(calculateNum.PrintSumOfNumbers);
            t1.Start();

            Console.WriteLine("Main thread end");
            Console.Read();
        }

        public static void PrintSumOfNumber(int sum)
        {
            Console.WriteLine("Sum of number = {0}", sum);
        }
    }

    public class CalculateNumber
    {

        readonly int _target;
        readonly SumOfNumbersCallback _callBackMethod;

        public CalculateNumber(int target,SumOfNumbersCallback callBackMethod)
        {
            _target = target;
            _callBackMethod = callBackMethod;
        }

        public void PrintSumOfNumbers()
        {
            int sum = 0;
            for (int i = 1; i <= _target; i++)
            {
                Console.WriteLine(i);
                sum += i;
            }

            _callBackMethod?.Invoke(sum);

        }
    }
}
