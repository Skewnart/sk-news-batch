using sk_news_batch.Exception;
using sk_news_batch.Module.Lifecycle;

namespace sk_news_batch_tests.Module.Lifecycle
{
    [TestClass]
    public class CheckLifecycleTest
    {
        /// <summary>
        /// Check that Check lifecycle needs argument.
        /// </summary>
        [TestMethod]
        public void TestHelpArgs()
        {
            string[] args = { };
            var checkLifecycle = new CheckLifecycle();
            Assert.ThrowsException<NoArgsException>(() => checkLifecycle.CheckArgs(args));

            args = new string[] { "-b" };
            Assert.ThrowsException<NoMandatoryArgsGivenException>(() => checkLifecycle.CheckArgs(args));

            args = new string[] { "-c", "-f" };
            Assert.ThrowsException<TooManyUniqueArgsGivenException>(() => checkLifecycle.CheckArgs(args));

            args = new string[] { "-c", "-b" };
            Assert.ThrowsException<ProhibitedArgsException>(() => checkLifecycle.CheckArgs(args));
        }
    }
}
