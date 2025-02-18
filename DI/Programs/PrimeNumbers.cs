using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI.Programs
{
    public class PrimeNumbers : IPrograms
    {
        public void execute()
        {
            // int p = 27;
            // IsPrimeNumber(p).Print($"is {p} is Prime Number ");

            // prime number between 1 to 100 ;
            // = new Range(1, 100) 
            List<int> primeList = new();
            foreach (var index in Enumerable.Range(1, 100))
            {
                if (IsPrimeNumber(index) == true)
                {
                    // "this is ".Print();
                    primeList.Add(index);

                }

            }
            primeList.Count().Print("total no in range");
            primeList.PrintAll();
        }

        public static bool IsPrimeNumber(int i)
        {
            if (i == 1) return false;
            if (i == 2) return true;
            if (i % 2 == 0) return false;

            int sqr = (int)Math.Ceiling(Math.Sqrt(i));
            for (int p = 3; p <= sqr; p += 2)
            {
                if (i % p == 0) return false;
            }
            return true;
        }
    }
}