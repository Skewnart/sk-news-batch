using sk_news_batch.Exception;
using sk_news_batch.Module.Lifecycle;

namespace sk_news_batch_tests.Module.Lifecycle
{
    [TestClass]
    public class ParseRSSStreamLifecycleTest
    {
        /// <summary>
        /// Check that Parse RSS Stream lifecycle can't have any argument from the caller.
        /// </summary>
        [TestMethod]
        public void TestRSSStreamArgs()
        {
            string[] args = { "-x" };
            var rssLifecycle = new ParseRSSStreamLifecycle();
            Assert.ThrowsException<CantHaveArgsException>(() => rssLifecycle.CheckArgs(args));
        }
    }
}
