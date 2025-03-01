using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI.Programs
{
    public class CountNoOfCharacters : IPrograms
    {
        public void execute()
        {
            string str = "aabaab";
            //    Dictionary keyValuePairs
            Dictionary<char, int> charCount = new();
            foreach (char c in str)
            {
                if (charCount.ContainsKey(c))
                {
                    charCount[c] += 1;
                }
                else
                {
                    charCount[c] = 1;
                }
            }

            charCount.PrintAll();
        
            str = "123abc3".ToUpper();
            int total = 0;
            var p = new Range(0, 9);
            string splitString = "" ;
            // p.Print();
            foreach (char c in str)
            {
                if (int.TryParse(c.ToString(), out int num))
                {
                    total += num;
                }
                else if (((int)c) >= ((int)'A') || ((int)c) <= ((int)'Z'))
                {
                   splitString += c ;
                }
            }
            splitString.Print();
        }
    }
}