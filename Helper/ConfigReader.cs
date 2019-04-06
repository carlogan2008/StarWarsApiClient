using System.IO;
using Newtonsoft.Json;
using StarWarsAPIClient.DataBase;

namespace StarWarsAPIClient.Helper
{
    public class ConfigReader
    {
        const string CONFIG_PATH = "./config.json";
        public static ConfigurationModel GetConfigurations(){
            var rawConfigAsText = File.ReadAllText(CONFIG_PATH);
            var config = JsonConvert.DeserializeObject<ConfigurationModel>(rawConfigAsText);
            return config;
        }
    }
}