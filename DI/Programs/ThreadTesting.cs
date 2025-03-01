using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI.Programs
{
    public class ThreadTesting : IPrograms
    {


        public void execute()
        {

            C1 c1 = new C1() ;
            C1 c2 = new C1() ;
            // Task t = theadTestingMethod();
            // t.Wait();
        }

        public async Task theadTestingMethod()
        {
            Task task1 = Task.Run(() =>
                      {
                          Thread.Sleep(5000);
                          Console.WriteLine("Task 1 completed");
                      });

            Task task2 = Task.Run(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine("Task 2 completed");
            });

            // Task.WaitAll(task1, task2); //  Blocks the main thread until all tasks complete
            await Task.WhenAll(task1, task2);  // Non-blocking, allows async execution 

            Console.WriteLine("Thread for wait skipped.");
            // Task.WaitAll(task1, task2);

        }
    }

    public   class C1
    {
        public C1(){
             "public".Print() ;
        }
        static C1( )
        {
            "tset".Print() ;
        }
    }
}