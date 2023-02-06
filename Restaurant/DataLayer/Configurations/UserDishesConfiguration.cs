using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations
{
    public class UserDishesConfiguration : IEntityTypeConfiguration<UserDishes>
    {
        public void Configure(EntityTypeBuilder<UserDishes> builder)
        {
            builder.HasKey(q => q.UserDishesId);

            builder.Property(q => q.UserId).IsRequired(false);
            builder.Property(q => q.DishId).IsRequired(false);

            builder.HasOne(q => q.User)
                   .WithMany(q => q.UserDishes)
                   .HasForeignKey(q => q.UserId);

            builder.HasOne(q => q.Dish)
                   .WithMany(q => q.UserDishes)
                   .HasForeignKey(q => q.DishId);
        }
    }
}
