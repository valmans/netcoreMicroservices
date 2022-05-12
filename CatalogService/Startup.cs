using AutoMapper;
using CatalogService.Data;
using CatalogService.Profiles;
using CatalogService.Repositories;
using CatalogService.SyncDataServices.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService
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
            services.AddDbContext<InMemDataContext>(opt => opt.UseInMemoryDatabase("InMem"));
            //services.AddSingleton<CosmosDbContext>(InitializeCosmosClientInstanceAsync(Configuration).GetAwaiter().GetResult());

            var AutomapperConfiguration = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PartnerProfile());
            });
            IMapper mapper = AutomapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IPartnerRespository, PartnerRepository>();

            services.AddHttpClient<IGiftcardDataClient, HttpGiftcardDataClient>();
            services.AddControllers();
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

            PrepDb.PopulateDatabase(app);
        }

        private static async Task<CosmosDbContext> InitializeCosmosClientInstanceAsync(IConfiguration configuration)
        {
            return await Task.FromResult(new CosmosDbContext(configuration));
        }
    }
}
