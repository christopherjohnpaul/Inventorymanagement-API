using Microsoft.Extensions.Configuration;
using System.IO;

namespace ModelLayer.Utility
{
    public class ConfigHelper
    {
        public ConfigHelper()
        {
            //Configuration Builder - Used to obtain configuration settings from a config/settings file (Builds a key/value structure).
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            //Setting the path to our appsettings.json file.
            string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            //Pass/Add the json files (Settings file) content to the configuration builder.
            configurationBuilder.AddJsonFile(path, false);
            //The builds a object consisting of the contents of settings file and maps them to a key/value structure/object [root is our object]
            Root = configurationBuilder.Build();
        }

        public IConfigurationRoot Root { get; set; }
    }
}
