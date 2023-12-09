using sk_news_batch.Modele;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

namespace sk_news_batch_tests.DAO
{
    [TestClass]
    public class ConfigurationDAOTest
    {
        [TestMethod]
        public void TestConfigurationFromYAML()
        {
            var deserializer = new DeserializerBuilder().Build();

            Assert.ThrowsException<SemanticErrorException>(() => { deserializer.Deserialize<Configuration>(yamlbadformat); });
            Assert.ThrowsException<YamlException>(() => { deserializer.Deserialize<Configuration>(yamlnomatching); });

            var configuration = deserializer.Deserialize<Configuration>(yamlnullconf);
            Assert.IsNull(configuration, "configuration should be null");
        }

        string yamlbadformat =
    @"newslifetime: 365
lang: en
tsdb:
 type: influxdb
  server: http://corentinz.fr:8050
 token: UNxEDNDoSGClDruFxMDhX-rVjKaBnnZyMyayJQETezHs43C3DIte73qC9NaHocWt93xP-obAnZliqbXRv5G0YA==
  bucket: sk-news
 organization: sk-corp";

        string yamlnomatching =
    @"newsltime: 365
lg: en
tdb:
  tye: influxdb
  seer: http://corentinz.fr:8050
  tken: UNxEDNDoSGClDruFxMDhX-rVjKaBnnZyMyayJQETezHs43C3DIte73qC9NaHocWt93xP-obAnZliqbXRv5G0YA==
  bket: sk-news
 orgation: sk-corp";

        string yamlnullconf =
    @"";
    }
}
