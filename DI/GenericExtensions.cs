namespace DI
{
    
    public static class GenericExtensions
    {
        public static T Print<T>(this T value, string s= "")
        {
            Console.WriteLine($"{s} : {value}");
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