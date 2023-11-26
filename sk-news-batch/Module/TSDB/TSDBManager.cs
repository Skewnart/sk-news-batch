namespace sk_news_batch.Module.TSDB
{
    public abstract class TSDBManager
    {
        /// <summary>
        /// Abstract Write method for TSBDManagers
        /// </summary>
        /// <param name="measurement"></param>
        /// <param name="tags"></param>
        /// <param name="fields"></param>
        /// <param name="timestamp"></param>
        public abstract void Write(string measurement, Dictionary<string, string> tags, Dictionary<string, string> fields, DateTime timestamp);
    }
}
