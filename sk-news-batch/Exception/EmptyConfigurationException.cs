namespace sk_news_batch.Exception
{
    public class EmptyConfigurationException : System.Exception
    {
        public EmptyConfigurationException() : base("Loaded configuration cannot be empty")
        {

        }
    }
}
