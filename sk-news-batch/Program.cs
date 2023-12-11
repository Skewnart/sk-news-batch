using sk_news_batch.Exception;
using sk_news_batch.Module.Lifecycle;
using sk_news_batch.Service;

namespace sk_news_batch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServiceProvider.InitServices();
            }
            catch(System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("An error occured while loading services. Program must end.");
                return;
            }

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
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
