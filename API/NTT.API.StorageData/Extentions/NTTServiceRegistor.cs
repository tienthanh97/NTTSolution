using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NTT.Business.ScrapingData;
using NTT.Contract.ScrapingData;
using NTT.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTT.API.StorageData.Extentions
{
    public static class NTTServiceRegistor
    {
        public static void ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IRealEstateBusiness, RealEstateBusiness>();
        }
    }
}
