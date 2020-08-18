using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TradeBotAPI.Services;

using Microsoft.OpenApi.Models;
using TradeBotAPI.Filters;
using MicroElements.Swashbuckle.FluentValidation;
using Newtonsoft.Json.Utilities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Swashbuckle.AspNetCore.Swagger;

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

        //public Startup(IWebHostEnvironment environment,
        //ILogger<Startup> logger)
        //{
        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(environment.ContentRootPath)
        //        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //        .AddJsonFile($"appsettings.{environment.EnvironmentName.ToLowerInvariant()}.json", optional: true)
        //        .AddEnvironmentVariables();
        //    this.Configuration = builder.Build();
        //    this.environment = environment;
        //    this.logger = logger;
        //}



        public IConfiguration Configuration { get; }

        readonly string apiVersion = "v1";
        readonly string apiName = "Demo ASP.NET Core Web API";
        readonly string apiDescription = "A simple ASP.NET Core Web API with Swagger and Fluent Validation";


        public void ConfigureServices(IServiceCollection services)
        {
            // HttpContextServiceProviderValidatorFactory requires access to HttpContext
            services.AddHttpContextAccessor();

            services.AddControllers()
                // Adds fluent validators
                .AddFluentValidation(c =>
                {
                    c.RegisterValidatorsFromAssemblyContaining<Startup>();
                    // Optionally set validator factory if you have problems with scope resolve inside validators.
                    c.ValidatorFactoryType = typeof(HttpContextServiceProviderValidatorFactory);

                    // we can disable other validation (for example, data annotations)
                    //c.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                });

            // Register all validators as IValidator?
            var serviceDescriptors = services.Where(descriptor => descriptor.ServiceType.GetInterfaces().Contains(typeof(IValidator))).ToList();
            serviceDescriptors.ForEach(descriptor => services.Add(ServiceDescriptor.Transient(typeof(IValidator), descriptor.ImplementationType)));

            // fluent validation, and an ActionFilter
            services.AddMvc(c =>
            {
                c.Filters.Add(typeof(ValidatorActionFilter));
            });

            services.AddHttpClient();

            // configuration
            var apiConfiguration = this.Configuration.GetSection("Settings").Get<ApiConfiguration>();

            // new config object, will be the same for everyone.
            services.AddSingleton<Config.IConfiguration>(apiConfiguration);

            //setup of our services
            services.AddTransient<IBrokerService, BrokerService>();
            services.AddTransient<IMarketService, MarketService>();

            // Swagger
            services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc("v1", new OpenApiInfo() { Title = "Web App", Version = "v1" });
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = apiName,
                    Description = apiDescription,
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "SOUTHWORKS",
                        Email = "teamstx@southworks.com",
                        Url = new Uri("https://www.southworks.com/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under License",
                        Url = new Uri("https://example.com/license"),
                    }
                });

                // Adds fluent validation rules to swagger
                c.AddFluentValidationRules();

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // // Adds swagger
            app.UseSwagger();

            // Adds swagger UI
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{apiVersion}/swagger.json", apiName);
            });
        }
    }
}
