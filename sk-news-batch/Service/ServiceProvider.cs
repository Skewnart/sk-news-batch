using sk_news_batch.Module.TSDB;

namespace sk_news_batch.Service
{
    public static class ServiceProvider
    {
        public static VersionProvider VersionProvider;
        public static LoggingProvider LoggingProvider;
        public static ConfigurationProvider ConfigurationProvider;
        public static void InitServices()
        {
            VersionProvider = VersionProvider.SetInstance();
            ConfigurationProvider = ConfigurationProvider.SetInstance();
            LoggingProvider = LoggingProvider.SetInstance(new InfluxDbManager(ConfigurationProvider.Configuration.Tsdb));
        }
    }
}
