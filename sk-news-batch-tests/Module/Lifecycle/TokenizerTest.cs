using sk_news_batch.Extension;
using sk_news_batch.Module.Lifecycle;

namespace sk_news_batch_tests.Module.Lifecycle
{
    [TestClass]
    public class TokenizerTest
    {
        [TestMethod]
        public void TestWithoutArguments()
        {
            var args = "".StringSplitSpace();
            var result = new Tokenizer(args).GetTokens();

            Assert.IsTrue(result.Length == 0);
        }

        [TestMethod]
        public void TestWithOneArgument()
        {
            var args = "-V".StringSplitSpace();
            var result = new Tokenizer(args).GetTokens();

            Assert.IsTrue(result.Length == 1);
        }

        [TestMethod]
        public void TestWithTwoArguments()
        {
            var args = "-T -u".StringSplitSpace();
            var result = new Tokenizer(args).GetTokens();

            Assert.IsTrue(result.Length == 2);

            args = "-T -vu".StringSplitSpace();
            result = new Tokenizer(args).GetTokens();

            Assert.IsTrue(result.Length == 3);
            Assert.IsTrue("-u".Equals(result[2]));
        }

        [TestMethod]
        public void TestWithOneSubargument()
        {
            var args = "-L 100".StringSplitSpace();
            var result = new Tokenizer(args).GetTokens();

            Assert.IsTrue(result.Length == 2);
            Assert.IsTrue("100".Equals(result[1]));
        }
    }
}
