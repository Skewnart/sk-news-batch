namespace sk_news_batch.Exception
{
    public class NoArgsException : System.Exception
    {
        /// <summary>
        /// No arguments were given for the specified command, but was expected
        /// </summary>
        /// <param name="context"></param>
        public NoArgsException(string context) : base($"{context} must have arguments") { }
    }
}
