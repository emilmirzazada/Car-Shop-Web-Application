using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

namespace carshop.webui
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddSession(o =>
            {
                o.IdleTimeout = TimeSpan.FromSeconds(1800);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                   Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
                RequestPath = "/modules"
            });

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "search",
                    pattern: "search",
                    defaults: new { controller = "Shop", action = "DetailedSearch" }
                    );

                endpoints.MapControllerRoute(
                    name: "cars",
                    pattern: "cars/{category?}",
                    defaults: new { controller = "Shop", action = "List" }
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Shop}/{action=List}/{id?}");
            });
        }
    }
}
