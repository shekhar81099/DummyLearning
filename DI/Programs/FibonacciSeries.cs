using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI.Programs
{
    public class FibonacciSeries : IPrograms
    {
        public void execute()
        {

            int no = 3;
            int[] fib = new int[no];

            // setting initial values 
            fib[0] = 0;
            fib[1] = 1;

            for (int i = 2; i < no; i++)
            {

                fib[i] = fib[i - 2] + fib[i - 1];


            }
            fib.PrintAll() ;
        }
    }
}