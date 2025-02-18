using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI.Programs
{
    public interface IPrograms
    {
        public void execute();
    }

    public static class ExecutePrograms
    {
        private static readonly IPrograms program = new PrimeNumbers();
        public static void RunPrograms()
        {
            program.execute();
        }
    }
}