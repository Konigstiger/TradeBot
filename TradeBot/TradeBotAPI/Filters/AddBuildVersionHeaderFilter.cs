using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeBotAPI.Config;

namespace TradeBotAPI.Filters
{
    public class AddBuildVersionHeaderFilter : IResultFilter
    {
        private readonly string buildVersion;

        public AddBuildVersionHeaderFilter(IConfiguration configuration)
        {
            this.buildVersion = configuration.BuildVersion;
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            //// do nothing
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("X-build-version",
                                                     new string[] { buildVersion });
        }
    }
}
