using sk_news_batch.Module.Lifecycle;

namespace sk_news_batch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            args = new Tokenizer(args).GetTokens();

            Lifecycle lifecycle = LifecycleChooser.Choose(args);
            lifecycle.Execute();
        }
    }
}
