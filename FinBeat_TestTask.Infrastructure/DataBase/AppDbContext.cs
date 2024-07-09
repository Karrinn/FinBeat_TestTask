using FinBeat_TestTask.Domain.Entities;
using FinBeat_TestTask.Infrastructure.DataBase.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FinBeat_TestTask.Infrastructure.DataBase
{
    public class AppDbContext : DbContext
    {
        public DbSet<Item> Items => Set<Item>();

        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ItemEntityConfiguration());
        }
    }
}
