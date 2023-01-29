﻿using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(q => q.UserId);

            builder.Property(q => q.UserId).HasDefaultValueSql("NEWID()");
            builder.Property(q => q.FirstName).HasMaxLength(50);
            builder.Property(q => q.LastName).HasMaxLength(50);
            builder.Property(q => q.PhoneNumber).HasMaxLength(50);
            builder.Property(q => q.Password).HasMaxLength(50);
            builder.Property(q => q.Email).HasMaxLength(50);
            builder.Property(q => q.PhoneNumber).IsRequired(false);
            builder.Property(q => q.PlaceId).IsRequired(false);
            builder.Property(q => q.DateOfReservation).IsRequired(false);

            builder.HasOne(q => q.Place)
                   .WithOne(q => q.User)
                   .HasForeignKey<User>(q => q.PlaceId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
