using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;

namespace sk_news_batch.Module.TSDB
{
    public class InfluxDbManager : TSDBManager
    {
        private readonly string _url;
        private readonly string _token;
        private readonly string _bucket;
        private readonly string _org;

        //TODO Injecter la configuration depuis le fichier adéquat
        public InfluxDbManager(/*configuration*/) {
            _url = "http://corentinz.fr:8050";
            _token = "UNxEDNDoSGClDruFxMDhX-rVjKaBnnZyMyayJQETezHs43C3DIte73qC9NaHocWt93xP-obAnZliqbXRv5G0YA==";
            _bucket = "sk-news";
            _org = "sk-corp";
        }

        /// <summary>
        /// Write method for InfluxDBManager
        /// </summary>
        /// <param name="measurement"></param>
        /// <param name="tags"></param>
        /// <param name="fields"></param>
        /// <param name="timestamp"></param>
        public override void Write(string measurement, Dictionary<string, string> tags, Dictionary<string, string> fields, DateTime timestamp)
        {
            using var client = new InfluxDBClient(_url, _token);
            using var write = client.GetWriteApi();

            var point = PointData.Measurement(measurement);

            foreach (var tag in tags)
                point = point.Tag(tag.Key, tag.Value);

            foreach (var field in fields)
                point = point.Field(field.Key, field.Value);

            point = point.Timestamp(timestamp, WritePrecision.Ns);

            write.WritePoint(point, _bucket, _org);
        }
    }
}
