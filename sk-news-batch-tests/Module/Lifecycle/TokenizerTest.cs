using sk_news_batch.Extension;
using sk_news_batch.Module.Lifecycle;

namespace sk_news_batch_tests.Module.Lifecycle
{
    [TestClass]
    public class TokenizerTest
    {
        /// <summary>
        /// Check if no token are found with empty argument array, and does not throw an exception.
        /// </summary>
        [TestMethod]
        public void TestWithoutArguments()
        {
            var args = "".StringSplitSpace();
            var result = new Tokenizer(args).GetTokens();

            Assert.IsTrue(result.Length == 0);
        }

        /// <summary>
        /// Check if one token is found.
        /// </summary>
        [TestMethod]
        public void TestWithOneArgument()
        {
            var args = "-V".StringSplitSpace();
            var result = new Tokenizer(args).GetTokens();

            Assert.IsTrue(result.Length == 1);
        }

        /// <summary>
        /// Check if two ad three tokens are found.
        /// </summary>
        [TestMethod]
        public void TestWithTwoAndThreeArguments()
        {
            var args = "-T -u".StringSplitSpace();
            var result = new Tokenizer(args).GetTokens();

            Assert.IsTrue(result.Length == 2);

            args = "-T -vu".StringSplitSpace();
            result = new Tokenizer(args).GetTokens();

            Assert.IsTrue(result.Length == 3);
            Assert.IsTrue("-u".Equals(result[2]));
        }

        /// <summary>
        /// Check sub-argument
        /// </summary>
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
