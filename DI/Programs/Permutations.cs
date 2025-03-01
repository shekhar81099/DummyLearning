using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI.Programs
{
    public class Permutations : IPrograms
    {
        public HashSet<string> comb = new();
        public string Swap(string s, int frmIdx, int toIdx)
        {
            char[] _s = s.ToCharArray();
            char tempChar = _s[frmIdx];
            _s[frmIdx] = _s[toIdx];
            _s[toIdx] = tempChar;

            return new string(_s);
        }

        public void GenStrings(string s, int left, int right)
        {
            if (left == right) { comb.Add(s); return; }
            for (int i = left; i <= right; i++)
            {
                s = Swap(s, left, i);
                GenStrings(s, left + 1, right);
                s = Swap(s, left, i);
            }
        }
        public void execute()
        {
            string s = "ABC";

            int charCount = s.Length;
            // Permute11(s, 0, charCount - 1);

            GenStrings(s, 0, charCount - 1);

            comb.Count().Print("total comb");
            comb.PrintAll();

        }
        public void Permute11(string str, int left, int right)
        {
            if (left == right)
            {
                // Console.WriteLine(str);
                comb.Add(str);
                return;
            }

            for (int i = left; i <= right; i++)
            {
                str = Swap(str, left, i); // Swap current index with left
                Permute11(str, left + 1, right); // Recur for next positions
                str = Swap(str, left, i); // Backtrack (swap back)
            }
        }
    }
}