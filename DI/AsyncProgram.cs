using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI
{
    public static class AsyncProgram
    {
        public static void  Test( )
        {
             
            RunAsync().Wait();
        }

        public static async Task DoWorkAsync(int i)
        {
            Console.WriteLine($"Starting {i}");
            await Task.Delay(i*1000);
            Console.WriteLine($"Ending {i}");
        }
        public static async Task RunAsync()
        {
             
            var tasks = new List<Task>();
            for (int i = 0; i < 2; i++)
            {
                tasks.Add(DoWorkAsync(i));
            }
            await DoWorkAsync(8);
            await Task.WhenAll(tasks);
        }
    }


    
}