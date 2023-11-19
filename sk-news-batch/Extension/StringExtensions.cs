using System.Linq;

namespace sk_news_batch.Extension
{
    public static class StringExtensions
    {
        public static string[] StringSplitSpace(this string str)
        {
            return str.Split(" ").Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
        }
    }
}
