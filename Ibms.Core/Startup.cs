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
using Microsoft.EntityFrameworkCore;
using Ibms.Core.Hubs;
using Ibms.Core.Models;
using Ibms.Core.Interfaces;
using Ibms.Core.Services;

namespace Ibms.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CoreContext>(opt =>
               opt
               .UseLoggerFactory(MyLoggerFactory)
               .UseSqlServer(Configuration.GetConnectionString("CoreDatabase"), options => options.EnableRetryOnFailure()));
            services.AddControllers();
            services.AddSignalR();

            services.AddSingleton<ICoreService>((container) =>
            {
                var logger = container.GetRequiredService<ILogger<CoreService>>();
                return new CoreService() { Logger = logger };
            });

            services.AddIdentityServer(options => options.Authentication.CookieAuthenticationScheme = "Cookies")
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(IdentityServerConfig.IdentityResources)
                .AddInMemoryApiResources(IdentityServerConfig.Apis)
                .AddInMemoryClients(IdentityServerConfig.Clients);

            services.AddAuthentication("Bearer")
                .AddCookie("Cookies")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:5001";
                    options.RequireHttpsMetadata = false;
                    options.Audience = "api1";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                logger.LogInformation("In Development environment");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseIdentityServer();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<MessageHub>("/messageHub");
            });
        }
    }
}
