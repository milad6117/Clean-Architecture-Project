using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trial.Core.Infrastructure;
using Trial.Data.Context;
using Trial.Data.Repositories;

namespace Trial.Data.Infrastructure
{
    public class DataBaseStartup : IApplicationStartup
    {
        public MiddleWarePriority Priority => MiddleWarePriority.AboveNormal;

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            services.AddDbContextPool<IApplicationContext, SqlServerApplicationContext>((option) =>
            {
                option.UseSqlServer("Data Source=.;Initial Catalog=TrialApp2;Integrated Security=true;Encrypt=false");
            }, poolSize: 16);
        }

        public void Configure(IApplicationBuilder app)
        {
           
        }


    }
}
