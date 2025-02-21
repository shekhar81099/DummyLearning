using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI.Programs
{
    public class MetricsProgram : IPrograms
    {
        public void execute()
        {
            int R = 4, C = 3;

            for (int i = 1; i <= R; i++) // for ROW
            {
                for (int j = 1; j <= C; j++) // Column
                {
                    if (i == j) Console.Write($"{i},{j} \t");
                    else if (i + j == R) Console.Write($"{i},{j} \t");
                    else Console.Write($"*,* \t");
                }
                "".Print();
            }
        }
    }
}