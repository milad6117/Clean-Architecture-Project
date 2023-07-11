using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial.Core.Infrastructure;
using Trial.Service.Catalog.customerService;

namespace Trial.Service.Infrastructure
{
    public class CommonStartup : IApplicationStartup
    {
        public MiddleWarePriority Priority => MiddleWarePriority.Normal;


        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
           services.AddScoped<ICustomerService, CustomerService>();
        }

        public void Configure(IApplicationBuilder app)
        {
        }

    }
}
