using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial.Core.Infrastructure;

namespace Trial.Framework.Infrastructure
{
    public class CommonStartup : IApplicationStartup
    {
        public MiddleWarePriority Priority => MiddleWarePriority.Normal;


        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddSwaggerGen();

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app)
        {
            IWebHostEnvironment env = app.ApplicationServices.GetService(typeof(IWebHostEnvironment)) as IWebHostEnvironment;
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>

                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shop API V1")
                    );

                //app.UseSwaggerUI();

            }

        }

 
    }
}
