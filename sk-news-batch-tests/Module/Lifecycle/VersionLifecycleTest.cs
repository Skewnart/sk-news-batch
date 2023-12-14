using sk_news_batch.Exception;
using sk_news_batch.Module.Lifecycle;
using sk_news_batch.Service;

namespace sk_news_batch_tests.Module.Lifecycle
{
    [TestClass]
    public class VersionLifecycleTest
    {
        /// <summary>
        /// Check that an exception is thrown when a prohibited argument is given.
        /// </summary>
        [TestMethod]
        public void TestVersionArgs()
        {
            string[] args = { "-t" };
            var versionLifecycle = new VersionLifecycle();
            Assert.ThrowsException<CantHaveArgsException>(() => versionLifecycle.CheckArgs(args));
        }

        /// <summary>
        /// Check if a version information is available. (need to be)
        /// </summary>
        [TestMethod]
        public void TestVersionNotNull()
        {
            VersionProvider.SetInstance();
            Assert.IsNotNull(VersionProvider.GetInstance().Version);
        }
    }
}
