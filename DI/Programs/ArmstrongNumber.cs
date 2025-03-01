using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI.Programs
{
    public class ArmstrongNumber : IPrograms
    {
        public void execute()
        {
            int no = 153;

            int l = no.ToString().Length;
            int total = 0;
            foreach (char c in no.ToString())
            {


                total += (int)Math.Pow(int.Parse(c.ToString()), l);

            }
            total.Print();

        }

    }
}