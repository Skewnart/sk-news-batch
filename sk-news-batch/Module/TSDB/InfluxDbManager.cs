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

        public InfluxDbManager(Modele.TSDB tsdb_configuration) {

            if (tsdb_configuration == null) throw new System.Exception("TSDB configuration is empty. Please fix it in the configuration file according to the documentation.");

            _url = tsdb_configuration.Server;
            _token = tsdb_configuration.Token;
            _bucket = tsdb_configuration.Bucket;
            _org = tsdb_configuration.Organization;
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
