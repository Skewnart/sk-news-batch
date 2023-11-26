namespace sk_news_batch.Module.Lifecycle
{
    public class Tokenizer
    {
        public string[] ReceivedArgs { get; private set; }
        private string[] _tokens = null;

        public Tokenizer(string[] args)
        {
            this.ReceivedArgs = args;
        }

        /// <summary>
        /// Retrieve tokens from the raw arguments
        /// </summary>
        /// <returns>Found tokens</returns>
        public string[] GetTokens()
        {
            if (_tokens == null)
            {
                List<string> tokenslist = new List<string>();
                foreach(string arg in this.ReceivedArgs)
                {
                    if (arg.StartsWith("-"))
                    {
                        //Extract each argument ("-tcv" into "-t -c -v")
                        tokenslist.AddRange(arg.Skip(1).Select(subarg => $"-{subarg}"));
                    }
                    else
                    {
                        tokenslist.Add(arg);
                    }
                }

                _tokens = tokenslist.ToArray();
            }

            return _tokens;
        }
    }
}
