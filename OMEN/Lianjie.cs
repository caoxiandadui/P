using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Extensions.Configuration.Json;
using System.IO;

namespace OMEN
{
    public class ConfigurationManager
    {
        public readonly static IConfiguration Configuration;
        static ConfigurationManager()
        {
            //
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .Build();
        }

        public static string conn
        {
            get { return Configuration.GetConnectionString("Default"); }
        }
    }
}
