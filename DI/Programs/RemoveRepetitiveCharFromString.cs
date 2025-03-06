using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI.Programs
{
    public class RemoveRepetitiveCharFromString : IPrograms
    {
        public void execute()
        {
            string ip = "this is this is the test code for test";
            string[] st = ip.Split(" ");
            HashSet<string> str = new HashSet<string>();
            foreach (string s in st)
            {
                str.Add(s);
            }
     
            str.Count().Print();
            str.Remove("is");
            str.Count().Print();
            str.PrintAll();
        }
    }
}