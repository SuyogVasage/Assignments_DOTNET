using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CS_Thread_Basic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Threading");
            Thread.CurrentThread.Name = "Main Thread";
            Console.WriteLine($"The Current Thread {Thread.CurrentThread.Name}\t" +
                $"{Thread.CurrentThread.ManagedThreadId}\t" +
                $"{Thread.CurrentThread.CurrentUICulture}\t" +
                $"{Thread.CurrentThread.Priority}\t");

            Thread t1 = new Thread(() => Increment());
            Thread t2 = new Thread(() => Decrement());
            t1.Start();
            t2.Priority = ThreadPriority.Highest;
            t2.Start();
            Console.ReadLine();
        }

        static void Increment()
        {

            Console.WriteLine($"Increment method thread id {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Increment = {i}");
                if(i == 5)
                {
                    Thread.Sleep(1000);
                }
            }
        }

        static void Decrement()
        {
            Console.WriteLine($"Decrement method thread id {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 10; i > 0; i--)
            {
                Console.WriteLine($"Decrement = {i}");
               /* if (i == 5)
                {
                    Thread.CurrentThread.Suspend();
                }*/
            }
        }
    }
}
