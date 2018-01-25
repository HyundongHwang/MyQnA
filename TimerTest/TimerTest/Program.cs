using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main TID : {Thread.CurrentThread.ManagedThreadId}");

            var timer = new Timer((arg) =>
            {
                Console.WriteLine($"timer callback TID : {Thread.CurrentThread.ManagedThreadId} start !!!");
                Thread.Sleep(3000);
                Console.WriteLine($"timer callback TID : {Thread.CurrentThread.ManagedThreadId} end !!!");
            }, null, 0, 1000);

            Console.ReadLine();
        }
    }
}
