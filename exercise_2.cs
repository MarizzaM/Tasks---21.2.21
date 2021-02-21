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
            var tasks = new Task[r.Next(1, 10)];

            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    for (int n = 1; n <= 10; n++) {
                        Console.WriteLine($"Task #{Task.CurrentId} -> {n}");
                        Thread.Sleep(100);
                    }
                });
            }

            for (int i = 0; i < tasks.Length; i++)
            {
               Task.WaitAll(tasks);
            }
        }
    }
}
