using sk_news_batch.Exception;
using sk_news_batch.Extension;
using sk_news_batch.Service;

namespace sk_news_batch.Module.Lifecycle
{
    public class CheckLifecycle : Lifecycle
    {
        public CheckType Type { get; set; }
        public bool IsVerbose { get; set; }

        public void CheckArgs(string[] args)
        {
            if (args?.Length == 0) throw new NoArgsException("Check lifecycle");

            string[] uniquemandatoryargs = { "-c", "-f" };
            int count = args.Intersect(uniquemandatoryargs).Count();

            if (count == 0) throw new NoMandatoryArgsGivenException(string.Join(", ", uniquemandatoryargs));
            if (count > 1) throw new TooManyUniqueArgsGivenException(string.Join(", ", uniquemandatoryargs));

            string[] allowedcommands = { "-c", "-f", "-v" };
            if (args.Any(arg => !allowedcommands.Contains(arg)))
                throw new ProhibitedArgsException("Check lifecycle", string.Join(", ", args.Where(arg => !allowedcommands.Contains(arg))));
        }

        public void Execute()
        {
            int confset = 0, totalconf = 0;
            var configuration = ServiceProvider.ConfigurationProvider.Configuration;

            if (this.IsVerbose)
                "Checking configuration file...".ToConsole();

            totalconf++;
            if (string.IsNullOrEmpty(configuration.Lang))
            {
                if (this.IsVerbose)
                    "Lang parameter is not set (lang)".ToConsole(ConsoleColor.Red);
            }
            else
            {
                if (this.IsVerbose)
                    $"Lang parameter is set to \"{configuration.Lang}\"".ToConsole(ConsoleColor.Green);
                confset++;
            }

            totalconf++;
            if (configuration.NewsLifetime == 0)
            {
                if (this.IsVerbose)
                    "News lifetime parameter is not set (newslifetime)".ToConsole(ConsoleColor.Red);
            }
            else
            {
                if (this.IsVerbose)
                    $"News lifetime parameter is set to \"{configuration.NewsLifetime}\" day{(configuration.NewsLifetime > 1 ? "s" : "")}".ToConsole(ConsoleColor.Green);
                confset++;
            }

            if (configuration.Tsdb == null)
            {
                if (this.IsVerbose)
                    "TSDB parameter is not set (tsdb)".ToConsole(ConsoleColor.Red);
            }
            else
            {
                string tsdb_type = configuration.Tsdb.Type;

                totalconf++;
                if (string.IsNullOrEmpty(tsdb_type))
                {
                    if (this.IsVerbose)
                        "TSDB type parameter is not set".ToConsole(ConsoleColor.Red);
                    tsdb_type = "TSDB";
                }
                else
                {
                    if (this.IsVerbose)
                        $"TSDB type parameter is set to \"{tsdb_type}\"".ToConsole(ConsoleColor.Green);
                    tsdb_type = tsdb_type.ToUpper();
                    confset++;
                }

                totalconf++;
                if (string.IsNullOrEmpty(configuration.Tsdb.Server))
                {
                    if (this.IsVerbose)
                        $"{tsdb_type} server parameter is not set".ToConsole(ConsoleColor.Red);
                }
                else
                {
                    if (this.IsVerbose)
                        $"{tsdb_type} server parameter is set to \"{configuration.Tsdb.Server}\"".ToConsole(ConsoleColor.Green);
                    confset++;
                }

                totalconf++;
                if (string.IsNullOrEmpty(configuration.Tsdb.Organization))
                {
                    if (this.IsVerbose)
                        $"{tsdb_type} organization parameter is not set".ToConsole(ConsoleColor.Red);
                }
                else
                {
                    if (this.IsVerbose)
                        $"{tsdb_type} organization parameter is set to \"{configuration.Tsdb.Organization}\"".ToConsole(ConsoleColor.Green);
                    confset++;
                }

                totalconf++;
                if (string.IsNullOrEmpty(configuration.Tsdb.Token))
                {
                    if (this.IsVerbose)
                        $"{tsdb_type} token parameter is not set".ToConsole(ConsoleColor.Red);
                }
                else
                {
                    if (this.IsVerbose)
                        $"{tsdb_type} token parameter is set".ToConsole(ConsoleColor.Green);
                    confset++;
                }

                totalconf++;
                if (string.IsNullOrEmpty(configuration.Tsdb.Bucket))
                {
                    if (this.IsVerbose)
                        $"{tsdb_type} bucket parameter is not set".ToConsole(ConsoleColor.Red);
                }
                else
                {
                    if (this.IsVerbose)
                        $"{tsdb_type} bucket parameter is set to \"{configuration.Tsdb.Bucket}\"".ToConsole(ConsoleColor.Green);
                    confset++;
                }
            }

            if (this.IsVerbose)
                "".ToConsole();
            
            $"{confset}/{totalconf} settings are set".ToConsole(confset == totalconf ? ConsoleColor.Green : ConsoleColor.Red);

            if (!this.IsVerbose && confset != totalconf)
                "To look at the misconfigured settings, please add the '-v' optional parameter.".ToConsole();
        }

        public void Init(string[] args)
        {
            this.Type = args.Contains("-c") ? CheckType.Configuration : CheckType.Stream;
            this.IsVerbose = args.Contains("-v");
        }
    }

    public enum CheckType
    {
        Configuration,  //configuration integrity
        Stream          //stream usage
    }
}
