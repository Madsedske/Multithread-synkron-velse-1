using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithread_synkron_øvelse_1
{
    internal class Program
    {
        static int second = 0;

        static object _lock = new object();
        static void Main(string[] args)
        {
            Thread t1 = new Thread(CountUp);
            t1.Start();

            Thread t2 = new Thread(CountDown);
            t2.Start();

            Console.ReadKey();
        }

        static void CountUp()
        {
            while (true)
            {
                Monitor.Enter(_lock); 

                try
                {
                    second += 2;
                    Console.WriteLine("Count up " + second);
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
                Thread.Sleep(1000);

            }
        }

        static void CountDown()
        {
            while (true)
            {
                Monitor.Enter(_lock);

                try
                {
                    second--;
                    Console.WriteLine("Count down " + second);
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
                Thread.Sleep(1000);
            }
        }
    }
}
