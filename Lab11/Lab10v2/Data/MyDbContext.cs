using Lab10v2.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab10v2.Data
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

        public DbSet<Lab10v2.Models.ShopCart> ShopCart { get; set; }
    }
}
