namespace sk_news_batch.Exception
{
    public class PathNotProvidedException : System.Exception
    {
        /// <summary>
        /// Given arguments are not allowed for the specified command. (any arguments or one of them)
        /// </summary>
        /// <param name="context"></param>
        public PathNotProvidedException(string needed_path) : base($"{needed_path} path is not provided") { }
    }
}
