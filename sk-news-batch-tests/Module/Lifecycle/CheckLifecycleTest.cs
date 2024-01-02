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
        public void TestCheckLifecycleArgs()
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

            args = new string[] { "-c", "-v" };
            checkLifecycle.CheckArgs(args);
            args = new string[] { "-f", "-v" };
            checkLifecycle.CheckArgs(args);
        }

        /// <summary>
        /// Check the Check Init lifecycle 
        /// </summary>
        [TestMethod]
        public void TestCheckLifecycleInit()
        {
            var checkLifecycle = new CheckLifecycle();
            var args = new string[] { "-c", "-v" };
            checkLifecycle.CheckArgs(args);
            checkLifecycle.Init(args);

            Assert.IsTrue(checkLifecycle.Type.Equals(CheckType.Configuration));
            Assert.IsTrue(checkLifecycle.IsVerbose);

            args = new string[] { "-f" };
            checkLifecycle.CheckArgs(args);
            checkLifecycle.Init(args);

            Assert.IsTrue(checkLifecycle.Type.Equals(CheckType.Stream));
            Assert.IsFalse(checkLifecycle.IsVerbose);
        }
    }
}
