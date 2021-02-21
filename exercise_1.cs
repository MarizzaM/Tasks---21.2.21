using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static Random r = new Random();
        static void Main(string[] args)
        {
            var tasks = new Task[10];
            AutoResetEvent are = new AutoResetEvent(true);
            for (int i = 0; i < tasks.Length; i++)
            {
                int num = i + 1;
                tasks[i] = Task.Run(() =>
                {
                    int timeSleep = r.Next(500, 2500);
                    Thread.Sleep(timeSleep);
                    are.WaitOne();
                    Console.WriteLine($"My name is {num}");
                });
            }

            for (int i = 0; i < tasks.Length; i++)
            {
               Task.WaitAny(tasks);
          }
        }
    }
}
