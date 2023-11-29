using YamlDotNet.Serialization;

namespace sk_news_batch.Modele
{
    public class Configuration
    {
        [YamlMember(Alias="newslifetime")]
        public int NewsLifetime { get; internal set; }
        [YamlMember(Alias = "lang")]
        public string Lang { get; internal set; }
        [YamlMember(Alias = "tsdb")]
        public TSDB Tsdb { get; internal set; }
    }
}
