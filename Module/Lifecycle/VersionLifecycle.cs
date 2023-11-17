using sk_news_batch.Service;

namespace sk_news_batch.Module.Lifecycle
{
    public class VersionLifecycle : Lifecycle
    {
        public void CheckArgs(string[] args)
        {
            if (args?.Length > 0) throw new Exception("Version lifecycle can't have arguments");
        }

        public void Init(string[] args) { }

        public void Execute()
        {
            Console.Write(ServiceProvider.VersionProvider.Version);
        }
    }
}
