using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations
{
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.HasKey(q => q.DishId);

            builder.Property(q => q.Name).HasMaxLength(50);
            builder.Property(q => q.Description).HasMaxLength(255);

            builder.HasIndex(q => new { q.Name, q.Price }).IsUnique();
        }
    }
}
