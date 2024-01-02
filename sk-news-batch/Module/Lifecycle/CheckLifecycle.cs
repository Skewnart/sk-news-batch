using InfluxDB.Client.Api.Domain;
using sk_news_batch.Exception;

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
            throw new NotImplementedException();
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
