using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Configurations
{
    public class UserDishesConfiguration : IEntityTypeConfiguration<UserDishes>
    {
        public void Configure(EntityTypeBuilder<UserDishes> builder)
        {
            builder.HasKey(q => q.UserDishesId);
            builder.Property(q => q.UserDishesId).HasDefaultValueSql("NEWID()");

            builder.HasIndex(q => new { q.UserId, q.DishId }).IsUnique();

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
