using InfluxDB.Client.Api.Domain;
using YamlDotNet.Serialization;

namespace sk_news_batch.Modele
{
    public class TSDB
    {
        [YamlMember(Alias = "type")]
        public string Type { get; internal set; }
        [YamlMember(Alias = "server")]
        public string Server { get; internal set; }
        [YamlMember(Alias = "token")]
        public string Token { get; internal set; }
        [YamlMember(Alias = "bucket")]
        public string Bucket { get; internal set; }
        [YamlMember(Alias = "organization")]
        public string Organization { get; internal set; }
    }
}
