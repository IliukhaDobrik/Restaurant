using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(q => q.UserId);

            builder.Property(q => q.FirstName).HasMaxLength(50);
            builder.Property(q => q.LastName).HasMaxLength(50);
            builder.Property(q => q.PhoneNumber).HasMaxLength(50);
            builder.Property(q => q.Password).HasMaxLength(50);
            builder.Property(q => q.Email).HasMaxLength(50);

            builder.HasIndex(q => q.Email).IsUnique();

            builder.Property(q => q.PhoneNumber).IsRequired(false);

            builder.HasOne(q => q.Place)
                   .WithOne(q => q.User)
                   .HasForeignKey<Place>(q => q.UserId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
