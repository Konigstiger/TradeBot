using System;
using System.Collections.Generic;
using System.Text;
using TradeBot.Core;

namespace TradeBotConsole.Gateways
{
    public class AuthService : IAuthService
    {
        public bool IsAuthenticated()
        {
            return true;
        }
    }
}
