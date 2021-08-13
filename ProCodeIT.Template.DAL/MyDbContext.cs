using Microsoft.EntityFrameworkCore;
using ProCodeIT.Template.Models.Entities;
using System.Linq;

namespace ProCodeIT.Template.DAL
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public IQueryable<Product> ProductsQuery { get => Products; }

        public DbSet<Product> Products { get; set; }

    }
}
