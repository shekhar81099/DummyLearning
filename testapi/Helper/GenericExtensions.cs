using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testapi.Helper
{
    public static class GenericExtensions
    {
        public static T Print<T>(this T value)
        {
            Console.WriteLine(value);
            return value;
        }

        public static bool IsNull<T>(this T obj) where T : class
        {
            return obj == null;
        }
        public static void PrintAll<T>(this IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}