namespace sk_news_batch.Exception
{
    public class EmptyConfigurationException : System.Exception
    {
        /// <summary>
        /// Empty configuration. (or maybe properties don't match)
        /// </summary>
        public EmptyConfigurationException() : base("Loaded configuration cannot be empty")
        {

        }
    }
}
