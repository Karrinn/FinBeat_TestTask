using FinBeat_TestTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinBeat_TestTask.Infrastructure.DataBase.Configurations
{
    public class ItemEntityConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Code)
                .IsRequired();

            builder
                .Property(x => x.Value)
                .IsRequired()
                .HasMaxLength(256);

            builder
                .Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
