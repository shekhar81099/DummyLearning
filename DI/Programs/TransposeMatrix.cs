using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI.Programs
{
    public class TransposeMatrix : IPrograms
    {
        public void execute()
        {
            int a = 3, b = 3, c = 1;
            int[,] array1 = new int[3, 3];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    array1[i, j] = c;
                    Console.Write($"{c} \t");
                    c++;
                }
                Console.WriteLine();
            }
            "transpose matrix".Print();
            // transposing the matrix = row to col
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                     
                    Console.Write($"{array1[j,i]  } \t");
                    c++;
                }
                Console.WriteLine();
            }

            // array1.Print();
        }
    }
}