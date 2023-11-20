namespace sk_news_batch.Exception
{
    public class ProhibitedArgsException : System.Exception
    {
        public ProhibitedArgsException(string context) : base($"{context} can't have arguments") { }
    }
}
