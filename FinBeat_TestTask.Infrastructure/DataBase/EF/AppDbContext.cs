using FinBeat_TestTask.Domain.Entities.Item;
using FinBeat_TestTask.Infrastructure.DataBase.EF.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FinBeat_TestTask.Infrastructure.DataBase.EF
{
    public class AppDbContext : DbContext
    {
        public DbSet<Item> Items => Set<Item>();


        public AppDbContext(DbContextOptions options) : base(options) 
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ItemEntityConfiguration());

        }
    }
}
