using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeBotAPI.Config
{
    public interface IConfiguration
    {
        string BuildVersion { get; set; }
        CredentialsConfiguration CredentialsConfiguration { get; }
    }
}
