using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorStyled;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Http;
using Blazored.LocalStorage;
using WEB701BalzorApp.infastructure;
using System.Data.Common;
using SQLReflectionMapper;
using System.Data.SqlClient;

namespace WEB701BalzorApp
{

    public static class SettingsManager
    {
        public static IConfiguration config = new ConfigurationBuilder()
          .AddJsonFile("appsettings.json", true, true)
          .Build();
    }
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();            
            services.AddBlazorStyled();
            services.AddBlazoredLocalStorage();
            services.AddScoped<AuthenticationStateProvider, BasicAuthStateProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            set.www = env.WebRootPath;

            app.Use((context, next) =>
            {
                //context.Request.PathBase = new PathString("/web701_so/net");
                return next.Invoke();
            });
            
            app.UsePathBase("/web701_so/net");

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);
            ConnectionSettings.data = SettingsManager.config.GetSection("ConnectionSettings").Get<CSData>();
            ConnectionSettings.data.InitProvider();



            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/a", async context =>
                {
                    await context.Response.WriteAsync(set.www);
                });
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
            Console.WriteLine(env.WebRootPath);
        }
    }

    public static class set
    {
        public static string www;
    }
}
