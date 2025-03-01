using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DI.Programs
{
    public class SecondLargestNumber : IPrograms
    {
        public void execute()
        {
            string t = "{\"name\":\"John\",\"age\":30,\"city\":\"New York\"}";
            // var tp = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(t);
            // tp["name"].Print();
            // tp.Print();
            
            var tp = System.Text.Json.JsonSerializer.Deserialize<object>(t);
            JsonElement jsonElement = (JsonElement)tp;
            ((JsonElement)tp).TryGetProperty("age1", out JsonElement nameElement) ;

            int[] arr = { 80, 10, 20, 150, 130 };
            int first = int.MinValue, second = int.MinValue;
            // arr.PrintAll() ;
            // int.MinValue.Print();
            "\n".Print();
            // Array.Sort(arr); // order in ascending 
            // minVal = arr[0];
            // MaxVal = arr[arr.Length-1];

            foreach (int num in arr) // 10, 20 ,80 ,150
            {
                if (num > first) // 10, 20-10, 80-20, 150-80
                {
                    second = first;
                    first = num;

                }
                else if (num > second && num < first) //80 > 20 && 80 < 
                {
                    second = num;
                }
            }
            if (second == int.MinValue)
            {

                Console.WriteLine($"Second Largest: {0}");
            }
            else
            {
                Console.WriteLine($"Second Largest: {second} , {first}");
            }
            // MaxVal.Print();
            // arr.PrintAll() ;


        }
    }


}