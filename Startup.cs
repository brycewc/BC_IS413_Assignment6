using BC_IS413_Assignment6.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BC_IS413_Assignment6
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<AmazonBooksDBContext>(options =>
               {
                   //Connection string. Defined in appsettings.json
                   options.UseSqlServer(Configuration["ConnectionStrings:AmazonBooksConnection"]);
               });

            services.AddScoped<IAmazonBooksRepository, EFAmazonBooksRepository>();
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "pagination",
                    "P{page}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapDefaultControllerRoute();
            });

            SeedData.EnsurePopulated(app); //For seeding data from SeedData.cs
        }
    }
}
