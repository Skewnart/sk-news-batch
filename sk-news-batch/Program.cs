using sk_news_batch.Exception;
using sk_news_batch.Module.Lifecycle;

namespace sk_news_batch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            args = new Tokenizer(args).GetTokens();
                
            try
            {
                Lifecycle lifecycle = LifecycleChooser.Choose(args);
                lifecycle.Execute();
            }
            catch(NotImplementedException) {
                Console.WriteLine("Used command is not implemented yet.");
            }
            catch (ProhibitedArgsException pae)
            {
                Console.WriteLine($"Bad command.\n{pae.Message}");
            }
            catch (MissingLifecycleException mle)
            {
                Console.WriteLine(mle.Message);
            }
        }
    }
}
