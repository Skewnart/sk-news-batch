namespace sk_news_batch.Service
{
    public class VersionProvider
    {
        /// ServiceProvider.VersionProvider.Version

        public Version Version { get; }

        private VersionProvider()
        {
            Version = new(0, 2, 0);
        }

        private static VersionProvider instance;
        public static VersionProvider GetInstance()
        {
            return instance ?? (instance = new VersionProvider());
        }
    }
}
