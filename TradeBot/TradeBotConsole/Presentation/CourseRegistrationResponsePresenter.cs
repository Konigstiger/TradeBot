using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TradeBot.Core;
using TradeBot.Core.Dto;

namespace TradeBotConsole.Presentation
{
    public class CourseRegistrationResponsePresenter
    {
        public CourseRegistrationResponseViewModel Handle(CourseRegistrationResponseMessage responseMessage)
        {
            if (responseMessage.Success)
            {
                return new CourseRegistrationResponseViewModel(true, "Course registration successful!");
            }

            var sb = new StringBuilder();
            sb.AppendLine("Failed to register course(s)");
            foreach (var e in responseMessage.Errors)
            {
                sb.AppendLine(e);
            }

            return new CourseRegistrationResponseViewModel(false, sb.ToString());
        }
    }
}
