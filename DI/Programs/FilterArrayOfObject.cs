using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI.Programs
{
    public class FilterArrayOfObject : IPrograms
    {

        // inputArray = {"rajesh|51|32|asd", "nitin|71|27|asd", "test|11|30|asd"}

        // output =  {"test|11|30|asd", "rajesh|51|32|asd" ,"nitin|71|27|asd"}

        public void execute()
        {
            string[] inputArray = { "rajesh|51|32|asd", "nitin|71|27|asd", "nitin|71|27|asd", "test|11|30|asd" };
            Dictionary<string, string> keyValuePairs = new();
            List<KeyValuePair<int, string>> li = new();
            foreach (var s in inputArray)
            {
                string[] i = s.Split("|");
                keyValuePairs[i[1]] = s;
                li.Add(new KeyValuePair<int, string>(int.Parse(i[1]), s));

            }



            li.Sort((x, y) => x.Key.CompareTo(y.Key));

            li.PrintAll();
            Console.WriteLine();

            var output = keyValuePairs.OrderBy(x => x.Key).Select(x => x.Value).ToArray();
            output.PrintAll();



        }

    }
}