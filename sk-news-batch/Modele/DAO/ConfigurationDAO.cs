using sk_news_batch.Exception;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

namespace sk_news_batch.Modele.DAO
{
    public static class ConfigurationDAO
    {
        public static Configuration FromYAML(string yaml)
        {
            Configuration config;

            try
            {
                var deserializer = new DeserializerBuilder().Build();
                config = deserializer.Deserialize<Configuration>(yaml);
            }
            catch (SyntaxErrorException ex) { throw new SyntaxErrorException("Syntax error on configuration file."); }

            if (config == null) throw new EmptyConfigurationException();

            return config!;
        }
    }
}
