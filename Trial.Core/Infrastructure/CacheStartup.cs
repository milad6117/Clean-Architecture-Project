using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial.Core.Caching;

namespace Trial.Core.Infrastructure
{
    public class CacheStartup:IApplicationStartup
    {

        public MiddleWarePriority Priority => MiddleWarePriority.Normal;


        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();
            services.AddDistributedRedisCache((option) =>
            {
                option.Configuration = "127.0.0.1:6379";
                option.InstanceName = "master";
            });
            services.AddScoped<ICacheManager,RedisCacheManager>();
        }

        public void Configure(IApplicationBuilder app)
        {

        }
    }
}
