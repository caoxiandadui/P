using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.IO;

namespace OMEN.Core.Common
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
            get { return Configuration.GetConnectionString("HN_BASEFRAME"); }
        }


    }
}
