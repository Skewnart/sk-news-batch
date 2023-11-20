namespace sk_news_batch.Exception
{
    public class ProhibitedArgsException : System.Exception
    {
        /// <summary>
        /// Given arguments are not allowed for the specified command. (any arguments or one of them)
        /// </summary>
        /// <param name="context"></param>
        public ProhibitedArgsException(string context) : base($"{context} can't have arguments") { }
    }
}
