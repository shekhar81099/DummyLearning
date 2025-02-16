using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using static System.Console;
namespace DI
{


    public class OppsTest
    {

        public OppsTest()
        {
 
            var ins = SingleTonDesignPattern.GetInstance;
            ins.DoSomething();
            // ins.DoSomething() ;
            
        }
    }
}