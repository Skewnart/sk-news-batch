namespace sk_news_batch.Exception
{
    public class MissingLifecycleException : System.Exception
    {
        public MissingLifecycleException() : base("Unknown lifecycle") { }
    }
}
