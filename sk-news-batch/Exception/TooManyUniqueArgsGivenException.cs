namespace sk_news_batch.Exception
{
    public class TooManyUniqueArgsGivenException : System.Exception
    {
        /// <summary>
        /// No arguments were given for the specified command, but was expected
        /// </summary>
        /// <param name="context"></param>
        public TooManyUniqueArgsGivenException(string args) : base($"Too many mandatory arguments given : {args}") { }
    }
}
