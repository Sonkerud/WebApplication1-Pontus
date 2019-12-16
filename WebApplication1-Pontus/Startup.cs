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
            //F�r dependency injection. Kunna skapa instans av CustomerService i konstruktorn f�r controllern.

            //services.AddTransient<CustomerService>();
            //G�r saker statiska utan att de �r satt till static. Konstruktorn f�r Customer Service k�rs bara en g�ng
            services.AddSingleton<CustomerService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) // St�lls in i launchSettings.json !
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting(); //Anv�nds f�r att mappa en URl mot en Action p� en controller.
                                // Ofta anv�nds ett attribut per action . [Route("")]
            
            //EndPoints - N�got som kan svara p� ett http-anrop
            app.UseEndpoints(endpoints => endpoints.MapControllers()
            );
        }
    }
}
