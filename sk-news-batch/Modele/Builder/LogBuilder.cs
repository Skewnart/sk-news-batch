namespace sk_news_batch.Modele.Builder
{
    public class LogBuilder
    {
        private Log _log;

        public LogBuilder()
        {
            _log = new Log();
        }

        public LogBuilder SetSite(string siteName)
        {
            _log.Site = siteName;
            return this;
        }

        public LogBuilder SetVersion(string version)
        {
            _log.Version = version;
            return this;
        }

        public LogBuilder SetCheckpassed(bool checkpassed)
        {
            _log.Checkpassed = checkpassed;
            return this;
        }

        public LogBuilder SetMessage(string message)
        {
            _log.Message = message;
            return this;
        }

        public LogBuilder SetTimestamp(DateTime timestamp)
        {
            _log.Timestamp = timestamp;
            return this;
        }

        public Log Build() {
            return _log;
        }
    }
}
