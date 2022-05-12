using CatalogService.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Data
{
    public class InMemDataContext : DbContext
    {
        public InMemDataContext(DbContextOptions<InMemDataContext> opt) : base(opt)
        {

        }

        public DbSet<Partner> Partners { get; set; }
       
    }
}
