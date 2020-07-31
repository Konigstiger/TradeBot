using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeBotAPI.Config;

namespace TradeBotAPI
{
    public class ApiConfiguration : IConfiguration
    {
        public string BuildVersion { get; set; }
        public CredentialsConfiguration CredentialsConfiguration { get; set; } = new CredentialsConfiguration();
        public BrokerConfiguration BrokerConfiguration { get; set; } = new BrokerConfiguration();
    }
}
