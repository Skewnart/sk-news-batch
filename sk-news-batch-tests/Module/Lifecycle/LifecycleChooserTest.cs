using sk_news_batch.Module.Lifecycle;

namespace sk_news_batch_tests.Module.Lifecycle
{
    [TestClass]
    public class LifecycleChooserTest
    {
        [TestMethod]
        public void TestChoose()
        {
            string[] args;
            sk_news_batch.Module.Lifecycle.Lifecycle lifecycle;

            args = new string[] { "-V" };
            lifecycle = LifecycleChooser.Choose(args);
            Assert.IsInstanceOfType(lifecycle, typeof(VersionLifecycle));

            args = new string[] { "-H" };
            lifecycle = LifecycleChooser.Choose(args);
            Assert.IsInstanceOfType(lifecycle, typeof(HelpLifecycle));
        }
    }
}
