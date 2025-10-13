using System;
using System.Threading;
using Microsoft.Extensions.Configuration;

namespace Util
{
    public class NetworkDelay
    {
        private static readonly NetworkDelaySettings _settings;

        static NetworkDelay()
        {
            var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables(prefix: "APP_")
            .Build();

            _settings = new NetworkDelaySettings();
            config.GetSection("NetworkDelay").Bind(_settings);
        }


        static public void SimulateNetworkDelay()
        {
            Random rnd = new Random();
            Thread.Sleep(rnd.Next(_settings.MinMs, _settings.MaxMs));
        }
    }
}
