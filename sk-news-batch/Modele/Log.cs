namespace sk_news_batch.Modele
{
    public class Log
    {
        public string Site { get; internal set; }
        public string Version { get; internal set; }
        public bool Checkpassed { get; internal set; }
        public string Message { get; internal set; }
        public DateTime Timestamp { get; internal set; }
    }
}
