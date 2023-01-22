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
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.HasKey(q => q.DishId);

            builder.Property(q => q.DishId).HasDefaultValueSql("NEWID()");
            builder.Property(q => q.Name).HasMaxLength(50);
            builder.Property(q => q.Description).HasMaxLength(255);
        }
    }
}
