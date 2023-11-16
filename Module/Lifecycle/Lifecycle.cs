namespace sk_news_batch.Module.Lifecycle
{
    public interface Lifecycle
    {
        void CheckArgs(string[] args);
        void Init(string[] args);
        void Execute();
    }
}
