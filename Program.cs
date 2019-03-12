using System;
using System.Threading;

namespace Threads
{
    class Program
    {
        private static void PrintNumbers()
        {
            for (int i = 0; i < 100; i++)
            {
                    Thread.Sleep(200);
                    Console.WriteLine($"Print in SECOND thread: {i}");
            }
        }

        private static void PrintNumbers2()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(300);
                Console.WriteLine($"Print in THIRD thread: {i}");
            }
        }

        static void Main(string[] args)
        {
            var secondThreadStart = new ThreadStart(PrintNumbers);
            var thirdThreadStart = new ThreadStart(PrintNumbers2);

            var thread = new Thread(secondThreadStart);
            thread.Start();

            var thread2 = new Thread(thirdThreadStart);
            thread2.Start();

            Console.WriteLine("Main thread sleep (5 seconds)");
            Thread.Sleep(5000);

            Console.ReadKey();
        }
    }
}
