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
                Console.Error.WriteLine(ex.Message);
                Console.Error.WriteLine("An error occured while loading services. Program must end.");
                return;
            }

            args = new Tokenizer(args).GetTokens();

            try
            {
                Lifecycle lifecycle = LifecycleChooser.Choose(args);
                lifecycle.Execute();
            }
            catch(NotImplementedException) {
                Console.Error.WriteLine("Used command is not implemented yet.");
            }
            catch (ProhibitedArgsException pae)
            {
                Console.Error.WriteLine($"Bad command.\n{pae.Message}");
            }
            catch (System.Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}
