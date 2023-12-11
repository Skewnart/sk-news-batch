namespace sk_news_batch.Exception
{
    public class CantHaveArgsException : System.Exception
    {
        /// <summary>
        /// The specified command is not supposed to have argument.
        /// </summary>
        /// <param name="context"></param>
        public CantHaveArgsException(string context) : base($"{context} can't have arguments") { }
    }
}
