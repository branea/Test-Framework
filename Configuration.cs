using System.IO;
using Microsoft.Extensions.Configuration;

namespace Test_Framework
{
    internal static class Configuration
    {
        public static IConfiguration AppSetting { get; }
        public static string ApplicationUrl => AppSetting["applicationUrl"];
        public static string UserName => AppSetting["username"];
        public static string Password => AppSetting["password"];

        static Configuration()
        {
            AppSetting = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("specflow.json")
                .Build();
        }
        

    }
}
