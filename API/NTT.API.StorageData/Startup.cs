using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NTT.API.StorageData.Extentions;
using NTT.Business.ScrapingData;
using NTT.Contract.ScrapingData;
using NTT.Data.NTTDBContext.NTTContexts;
using NTT.Data.Repositories;
namespace NTT.API.StorageData
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<IISServerOptions>(options => { options.AutomaticAuthentication = false; });
            services.AddControllers();
            // config for Cors Policy
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
          
            services.AddSingleton(Configuration);
            services.AddDbContext<TrackingNpgDBContext>(opts => opts.UseNpgsql(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddScoped<DbContext, TrackingNpgDBContext>();
            services.ConfigureApplicationServices(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
