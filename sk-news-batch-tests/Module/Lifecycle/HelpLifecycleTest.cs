using sk_news_batch.Module.Lifecycle;

namespace sk_news_batch_tests.Module.Lifecycle
{
    [TestClass]
    public class HelpLifecycleTest
    {
        [TestMethod]
        public void TestHelpArgs()
        {
            string[] args = { "-t" };
            var helpLifecycle = new HelpLifecycle();
            Assert.ThrowsException<Exception>(() => helpLifecycle.CheckArgs(args));
        }
    }
}
