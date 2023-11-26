using sk_news_batch.Module.TSDB;

namespace sk_news_batch.Service
{
    public static class ServiceProvider
    {
        public static VersionProvider VersionProvider = VersionProvider.SetInstance();
        public static LoggingProvider LoggingProvider = LoggingProvider.SetInstance(new InfluxDbManager());
    }
}
