namespace sk_news_batch.Exception
{
    public class MissingLifecycleException : System.Exception
    {
        /// <summary>
        /// Lifecyce unknown for now
        /// </summary>
        public MissingLifecycleException() : base("Unknown lifecycle") { }
    }
}
