using sk_news_batch.Exception;
using sk_news_batch.Module.Lifecycle;

namespace sk_news_batch_tests.Module.Lifecycle
{
    [TestClass]
    public class HelpLifecycleTest
    {
        /// <summary>
        /// Check that Help lifecycle can't have any argument from the caller.
        /// </summary>
        [TestMethod]
        public void TestHelpArgs()
        {
            string[] args = { "-t" };
            var helpLifecycle = new HelpLifecycle();
            Assert.ThrowsException<CantHaveArgsException>(() => helpLifecycle.CheckArgs(args));
        }
    }
}
