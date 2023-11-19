namespace sk_news_batch.Service
{
    public class VersionProvider
    {
        public Version Version { get; }

        private VersionProvider()
        {
            Version = new(0, 1, 0);
        }

        private static VersionProvider instance;
        public static VersionProvider GetInstance()
        {
            return instance ?? (instance = new VersionProvider());
        }
    }
}
