using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TestWeb1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
             //Fornisco i servizi MVC necessari per il middleware di routing
             services.AddMvc()
             #if DEBUG
             .AddRazorRuntimeCompilation()
             #endif
             ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //EndPointRoutingMiddleware
            app.UseRouting();

            //1° Middleware
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
          
            //2° Middleware per file statici
            app.UseStaticFiles();
            
            //EndPointMiddleware
            app.UseEndpoints(routeBuilder =>
            {
                routeBuilder.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                
            });

        }
    }
}
