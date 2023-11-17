namespace sk_news_batch.Module.Lifecycle
{
    public interface Lifecycle
    {
        /// <summary>
        /// Check that the arguments are syntactically, grammatically and semantically correct
        /// syntactically : argument character must be a letter
        /// grammatically : argument must match a known argument for the command
        /// semantically : arguments may not coexist together
        /// </summary>
        /// <param name="args">the arguments</param>
        void CheckArgs(string[] args);

        /// <summary>
        /// Init implementer properties with raw args
        /// </summary>
        /// <param name="args"></param>
        void Init(string[] args);

        /// <summary>
        /// Execute implementer process
        /// </summary>
        void Execute();
    }
}
