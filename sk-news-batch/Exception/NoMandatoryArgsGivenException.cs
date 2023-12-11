namespace sk_news_batch.Exception
{
    public class NoMandatoryArgsGivenException : System.Exception
    {
        /// <summary>
        /// No arguments were given for the specified command, but was expected
        /// </summary>
        /// <param name="context"></param>
        public NoMandatoryArgsGivenException(string args) : base($"Mandatory argument needed : {args}") { }
    }
}
