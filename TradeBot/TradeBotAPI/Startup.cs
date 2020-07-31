using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TradeBotAPI.Services;

namespace TradeBotAPI
{
    public class Startup
    {
        private readonly IWebHostEnvironment environment;
        private readonly ILogger<Startup> logger;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // INFO: I dont know if this line is necessary. Also, there is .AddMvcCore()
            services.AddMvc();
            //services.AddMvcCore();
            //services.AddMvcCore().AddApiExplorer();

            services.AddHttpClient();

            // test: read from json?
            // TODO: create classes isomorphic with json
            //var apiConfiguration = this.Configuration.GetSection("Settings").Get<ApiConfiguration>();
            var apiConfiguration = this.Configuration.GetSection("Settings").Get<ApiConfiguration>();

            // new config object, will be the same for everyone.
            services.AddSingleton<Config.IConfiguration>(apiConfiguration);

            //setup of our services
            services.AddTransient<IBrokerService, BrokerService>();
            services.AddTransient<IMarketService, MarketService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
