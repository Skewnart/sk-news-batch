using sk_news_batch.Modele;
using sk_news_batch.Module.TSDB;

namespace sk_news_batch.Service
{
    public class LoggingProvider
    {
        /// use : ServiceProvider.LoggingProvider.LogStreamSiteCheck(string, string, bool, string)

        private TSDBManager manager { get; }

        private LoggingProvider(TSDBManager tsdbManager)
        {
            manager = tsdbManager;
        }

        private static LoggingProvider instance;
        public static LoggingProvider GetInstance() { return instance; }
        public static LoggingProvider SetInstance(TSDBManager tsdbManager)
        {
            return instance ?? (instance = new LoggingProvider(tsdbManager));
        }

        public void LogStreamSiteCheck(Log log)
        {
            this.manager.Write(
                "streamcheck",
                new Dictionary<string, string>() { { "site", log.Site }, { "version", log.Version }, { "check", log.Checkpassed ? "OK" : "KO" } },
                new Dictionary<string, string>() { { "message", log.Checkpassed ? "OK" : log.Message } },
                log.Timestamp
                );
        }
    }
}
