using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TradeBot.Core;

namespace TradeBotConsole.Presentation
{
    public class CourseRegistrationResponseViewModel
    {
        public bool Success { get; private set; }
        public string ResultMessage { get; private set; }

        public CourseRegistrationResponseViewModel(bool success, string resultMessage)
        {
            Success = success;
            ResultMessage = resultMessage;
        }
    }
}
