using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI
{
    public class Test1111
    {
        protected int p1 = 50;
    }
    public class DelegateExample : Test1111
    {
        Test1111 test1111 = new Test1111();


        public delegate object PrintMsg();
        public string print1() => "test 1".Print();
        public string print2() => "test 2".Print();

        public void CallbackExample(PrintMsg pr)
        {
            p1.Print();
            var p = pr.GetInvocationList().Cast<PrintMsg>().Select(d => d.Invoke()).ToArray();
            p.PrintAll();


        }
        public DelegateExample()
        {
            PrintMsg printMsg = new(print1);
            printMsg += print2;
            // printMsg.Invoke();
            CallbackExample(printMsg);
        }


    }
}