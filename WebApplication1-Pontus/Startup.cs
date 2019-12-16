using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication1_Pontus.Models;

namespace WebApplication1_Pontus
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //För dependency injection. Kunna skapa instans av CustomerService i konstruktorn för controllern.

            //services.AddTransient<CustomerService>();
            //Gör saker statiska utan att de är satt till static. Konstruktorn för Customer Service körs bara en gång
            services.AddSingleton<CustomerService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) // Ställs in i launchSettings.json !
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting(); //Används för att mappa en URl mot en Action på en controller.
                                // Ofta används ett attribut per action . [Route("")]
            
            //EndPoints - Något som kan svara på ett http-anrop
            app.UseEndpoints(endpoints => endpoints.MapControllers()
            );
        }
    }
}
