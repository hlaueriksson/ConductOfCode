using System.Collections.Generic;
using ConductOfCode.Extensions;
using ConductOfCode.Models;
using ConductOfCode.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace ConductOfCode
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddSingleton(new Stack<Item>());

            services.AddOptions();
            services.Configure<TokenOptions>(Configuration.GetSection(nameof(TokenOptions)));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "ConductOfCode", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ConductOfCode");
                c.InjectOnCompleteJavaScript("/swagger-ui/authorization1.js");
                //c.InjectOnCompleteJavaScript("https://cdnjs.cloudflare.com/ajax/libs/crypto-js/3.1.9-1/crypto-js.min.js"); // https://cdnjs.com/libraries/crypto-js
                //c.InjectOnCompleteJavaScript("/swagger-ui/authorization2.js");
            });

            app.UseStaticFiles();

            var options = Configuration.GetSection(nameof(TokenOptions)).Get<TokenOptions>();

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                TokenValidationParameters =
                {
                    ValidAudience = options.Audience,
                    ValidIssuer = options.Issuer,
                    IssuerSigningKey = options.GetSymmetricSecurityKey()
                }
            });

            app.UseMvc();
        }
    }
}