namespace sk_news_batch.Service
{
    public class VersionProvider
    {
        /// use : ServiceProvider.VersionProvider.Version

        public Version Version { get; }

        private VersionProvider()
        {
            Version = new(0, 3, 1);
        }

        private static VersionProvider instance;
        public static VersionProvider GetInstance() { return instance; }
        public static VersionProvider SetInstance()
        {
            return instance ?? (instance = new VersionProvider());
        }
    }
}
