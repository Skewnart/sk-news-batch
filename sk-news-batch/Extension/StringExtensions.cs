using System.Linq;

namespace sk_news_batch.Extension
{
    public static class StringExtensions
    {
        public static string[] StringSplitSpace(this string str)
        {
            return str.Split(" ").Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
        }

        public static void ToConsole(this string str, ConsoleColor foregroundColor = ConsoleColor.White)
        {
            var color_temp = Console.ForegroundColor;

            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(str);
            Console.ForegroundColor = color_temp;
        }
    }
}
