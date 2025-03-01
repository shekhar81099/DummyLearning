using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI.Programs
{
    public class ReverseStringByRecursion : IPrograms
    {
        string a = "shekhar";
        public void execute()
        {

            int l = a.Length - 1;
            revFun(l).Print();

        }
        public string revFun(int l)
        {
            string r = a[l].ToString();
            l -= 1;
            if (l < 0)
            {
                return r;
            }
            return r + revFun(l);
        }

    }
}