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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //1° Middleware
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //2° Middleware
            app.UseStaticFiles();

            //3° Middleware
            app.UseRouting();

            //4° Middleware
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    //Inserimento dati in QueryString
                    string nome = context.Request.Query["nome"];
                    await context.Response.WriteAsync($"Hello {nome}");
                });
            });
        }
    }
}
