using sk_news_batch.Module.Lifecycle;
using sk_news_batch.Service;

namespace sk_news_batch_tests.Module.Lifecycle
{
    [TestClass]
    public class VersionLifecycleTest
    {
        [TestMethod]
        public void TestVersionArgs()
        {
            string[] args = { "-t" };
            var versionLifecycle = new VersionLifecycle();
            Assert.ThrowsException<Exception>(() => versionLifecycle.CheckArgs(args));
        }

        [TestMethod]
        public void TestVersionNotNull()
        {
            Assert.IsNotNull(ServiceProvider.VersionProvider.Version);
        }
    }
}
