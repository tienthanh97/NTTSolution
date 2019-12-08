using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NTT.Business.ScrapingData;
using NTT.Contract.ScrapingData;
using NTT.Data.NTTDBContext.NTTContexts;
using NTT.Data.Repositories;

namespace RealEstateWorker
{
    public class Program
    {
        private static IConfiguration Configuration { get; set; }

        public static void Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder()
                     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = configBuilder.Build();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    var workerType = Configuration["WorkerService:workerType"];
                    if (workerType == "ScrapingCustomerWorker")
                    {
                        services.AddHostedService<ScrapingCustomerWorker>();
                    }
                    else if (workerType == "TestWorker")
                    {
                        services.AddHostedService<TestWorker>();
                    }
                    else
                    {
                        services.AddHostedService<DrawingDataWorker>();

                    }
                 

                    services.AddSingleton(Configuration);
                    services.AddDbContext<TrackingNpgDBContext>(opts =>
                                            opts.UseNpgsql(Configuration["ConnectionStrings:DefaultConnection"])
                                            , ServiceLifetime.Singleton);
                    services.AddSingleton<DbContext, TrackingNpgDBContext>();
                    services.AddSingleton(typeof(IRepository<>), typeof(EfRepository<>));
                    services.AddSingleton<IRealEstateBusiness, RealEstateBusiness>();
                    services.AddSingleton<ICustomerScrapingBusiness, CustomerScrapingBusiness>();

                });
    }
}
