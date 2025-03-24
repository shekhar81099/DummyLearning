using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI.Programs
{
    public class cancellationToken : IPrograms
    {
        public void execute()
        {




            ICollection<string> fruits = new List<string> { "Apple", "Banana", "Mango" };

            fruits.Add("Orange");
            fruits.Remove("Banana");

            IList<string> myToys = new string[] { "Car", "Truck", "Bike" };
            // myToys.Add("test"); 
            Console.WriteLine(myToys[0]);


            // MaxThreadCount();
            // // MainMethod11().Wait();
            // object locker = new object();
            // List<int> list = new List<int>();
            // ConcurrentBag<int> bag = new ConcurrentBag<int>();
            // Parallel.For(0, 10, i =>
            // {
            //     lock (locker) // ✅ Locks the list
            //     {
            //         list.Add(i);
            //     }
            //     bag.Add(i);
            //     // list.Add(i); // ❌ Not Thread-Safe! Can cause issues
            // });
            // // bag.PrintAll();
            // // " ".Print();
            // // list.PrintAll();
            // int processorCount = Environment.ProcessorCount;
            // Console.WriteLine($"Logical Processors: {processorCount}");

            // ThreadPool.GetAvailableThreads(out int workerThreads, out int ioThreads);
            // Console.WriteLine($"Worker Threads: {workerThreads}, I/O Threads: {ioThreads}");

            // list.Sort();
            // Parallel.ForEach(list, l =>
            // {
            //     Thread.CurrentThread.ManagedThreadId.Print();
            //     l.Print();
            // });
        }

        public async Task MainMethod11()
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            Task task = DoWorkAsync(cts.Token);

            await Task.Delay(3000); // Simulate some processing
            cts.Cancel(); // Request cancellation

            try
            {
                await task; // Await task completion
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Task was cancelled!");
            }
        }

        public async Task DoWorkAsync(CancellationToken token)
        {
            for (int i = 1; i <= 10; i++)
            {
                token.ThrowIfCancellationRequested(); // Check if cancellation is requested

                Console.WriteLine($"Processing {i}...");
                await Task.Delay(5000); // Simulate work
            }
            Console.WriteLine("Task completed!");
        }

        public void MaxThreadCount()
        {
            // {
            //     int count = 0;
            //     try
            //     {
            //         while (true)
            //         {
            //             new Thread(() =>
            //             {
            //                 Thread.Sleep(Timeout.Infinite);
            //             }).Start();
            //             count++;
            //             Console.WriteLine($"Thread Count: {count}");
            //         }
            //     }
            //     catch (Exception ex)
            //     {
            //         Console.WriteLine($"Max Threads Reached: {count}");
            //         Console.WriteLine(ex.Message);
            //     }
            // }
        }
    }

}