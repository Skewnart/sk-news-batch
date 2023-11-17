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
            //TODO version display
            return;
        }
    }
}
