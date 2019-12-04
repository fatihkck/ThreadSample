using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _25_MutexSmephoreSmephoreSlim
{
    class Program
    {
        //initialCount 1 demek aynı anda sadece tek bir thread başlıyacağını söyle, 3 derseniz aynı anda thread başlayacaktır.
        static SemaphoreSlim semaphore = new SemaphoreSlim(initialCount: 3);

        static void Main(string[] args)
        {

            /*
             Mutext : Bazı durumlarda bir kaynağı birden fazla thread kullanmak isteyebilir bu durumda deadlock lar meydana gelebilir bu durumları engellemek için mutex kullanılır, kısaca mutex bir thread işlem yaparken diğer threadların onu beklemesidir
             Mutex sınıfı monitor sınıfına benzer ancak System.Threading.WaitHandle sınıfından türetilmiştir ve türediğin sınıfın daha kolay kullanılabilir bir genelleştirilmesidir. Mutex sınıfı kanallar tarafından ortak kullanılan nesnelere aynı anda ulaşılıp, işlem yapılmasını engellemek için kullanılır. Mutex sınıfı ortak kullanılan kaynaklara bir t zamanında sadece bir kanalın ulaşabilmesini garanti eder. Mutex kendisini kullanan kanalın tekilliğini (identity) kontrol eder. Bir mutex’e sahip olan kanal WaitOne metodu ile onu kilitler ve ReleaseMutex metodu ile mutex’i serbest bırakır. Bir mutex kullanan kanal sadece kendi mutex’ini ReleaseMutex metodu ile açabilir. Kanallar birbirlerinin mutex’lerini serbest bırakamaz. 
    */


            /*
             Semaphore : Semaphore sınıfının Mutex sınıfından farkı, farklı kanalların birbirlerinin Semaphore’larının kilitlerini Release metodu ile açabilmeleridir. Bir kanal semaphore’un WaitOne metodunu birçok kez çağırabilir. Bu kilitleri açmak için art arda Release metodunu çağırabileceği gibi, Release(int) overload’unu da kullanabilir. Semaphore kendisini kullanan kanalın identity’sine bakmaz. Bu yüzden farklı kanallar birbirlerinin semaphore’larının WaitOne ve Release metodlarını çağırabilir. Herbir WaitOne metodu çağırıldığında semaphore’un sayacı bir azaltılır. Herbir release metodu çağırıldığında ise sayaç bir arttırılır. Semaphore’un yapılandırıcısında (constructor) sayacın minimum ve maksimum değerleri belirlenebilir.
             */

            /*
            SemaphoreSlim Semaphore ise sizin threadlerinizi yönetmenizi sağlayan bir mekanizma, bu mekanizma ile uygulamada kaç tane thread çalışacağını belirterek bütün threadlerinizi bir sıraya koyabilirsiniz. Uygulamanızda aynı anda 5 thread çalışsın diyebilirsiniz bu durumda n anında açılan 6. thread diğer 5 thread’den birinin işini bitirmesini bekler.
            Bu mekanizmayı elbette kendinizde yapabilirsiniz fakat .Net Framework 4.0 ile gelen SemaphoreSlim class’ı ile bu mekanizmayı uygulamanıza entegre etmek çok kolay. Sınıfın iki tane fonksiyonu var; wait ve release bu iki fonksiyon ile programınızdaki tüm threadleri kontrol edebilirsiniz
              */


            for (int i = 0; i < 5; i++)
            {
                new Thread(Process).Start(i);
            }


            Console.Read();
        }

        public static void Process(object threadNumber)
        {
            Console.WriteLine(string.Format("Thread Number: {0} wait", (int)threadNumber));
            semaphore.Wait();
            Console.WriteLine(string.Format("Thread Number: {0} start", (int)threadNumber));
            Thread.Sleep(1000);
            Console.WriteLine(string.Format("Thread Number: {0} finish", (int)threadNumber));
            semaphore.Release();
            Console.WriteLine("-------------");
        }
    }
}
