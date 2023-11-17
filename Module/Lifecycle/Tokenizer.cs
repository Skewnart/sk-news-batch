﻿namespace sk_news_batch.Module.Lifecycle
{
    public class Tokenizer
    {
        public string[] ReceivedArgs { get; private set; }
        private string[] tokens = null;

        public Tokenizer(string[] args)
        {
            this.ReceivedArgs = args;
        }

        public string[] GetTokens()
        {
            if (tokens == null)
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
                
                tokens = tokenslist.ToArray();
            }

            return tokens;
        }
    }
}
