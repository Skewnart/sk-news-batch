using sk_news_batch.Exception;

namespace sk_news_batch.Module.Lifecycle
{
    public class ParseRSSStreamLifecycle : Lifecycle
    {
        public void CheckArgs(string[] args)
        {
            if (args?.Length > 0) throw new CantHaveArgsException("Parse RSS Stream lifecycle");
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void Init(string[] args)
        {

        }
    }
}
