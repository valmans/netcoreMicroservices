using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CatalogService.Data
{
    public static class PrepDb
    {
        public static void PopulateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<InMemDataContext>());
            }
        }

        private static void SeedData(InMemDataContext context)
        {
            if (!context.Partners.Any())
            {
                Console.WriteLine("--> Seeding data");
                context.Partners.AddRange(
                    new Models.Partner() { Id = "1", Name = "Partner 1" },
                    new Models.Partner() { Id = "2", Name = "Partner 2" },
                    new Models.Partner() { Id = "3", Name = "Partner 3" },
                    new Models.Partner() { Id = "4", Name = "Partner 4" }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
