using sk_news_batch.Exception;
using sk_news_batch.Modele;
using sk_news_batch.Modele.DAO;

namespace sk_news_batch.Service
{
    public class ConfigurationProvider
    {
        /// use : ServiceProvider.ConfigurationProvider.

        private static readonly string DEFAULTCONFIGURATIONPATH = "configuration.yaml";

        private string _configuration_path { get; }
        public Configuration Configuration { get; private set; }

        private ConfigurationProvider(string configuration_path)
        {
            _configuration_path = configuration_path;
            loadConfiguration();
        }

        private static ConfigurationProvider instance;
        public static ConfigurationProvider GetInstance() { return instance; }
        public static ConfigurationProvider SetInstance(string configuration_path = null)
        {
            return instance ?? (instance = new ConfigurationProvider(configuration_path ?? DEFAULTCONFIGURATIONPATH));
        }

        /// <summary>
        /// Load configuration from config file or default if does not exist
        /// </summary>
        /// <exception cref="PathNotProvidedException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="EmptyConfigurationException"></exception>
        private void loadConfiguration()
        {
            if (_configuration_path == null) throw new PathNotProvidedException("Configuration file");

            string strWorkPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)!;
            string configurationfile = Path.Combine(strWorkPath, _configuration_path);

            if (!File.Exists(configurationfile)) throw new FileNotFoundException();

            string configuration = File.ReadAllText(_configuration_path);
            if(string.IsNullOrWhiteSpace(configuration)) throw new EmptyConfigurationException();

            this.Configuration = ConfigurationDAO.FromYAML(configuration);
        }
    }
}
