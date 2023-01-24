﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230123185639_SomeChanges")]
    partial class SomeChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Dish", b =>
                {
                    b.Property<Guid>("DishId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DishId");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("Entities.Place", b =>
                {
                    b.Property<Guid>("PlaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<bool>("IsFree")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PlaceId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("DateOfReservation")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("PlaceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId");

                    b.HasIndex("PlaceId")
                        .IsUnique()
                        .HasFilter("[PlaceId] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.UserDishes", b =>
                {
                    b.Property<Guid>("UserDishesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("DishId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserDishesId");

                    b.HasIndex("DishId");

                    b.HasIndex("UserId", "DishId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL AND [DishId] IS NOT NULL");

                    b.ToTable("UserDishes");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.HasOne("Entities.Place", "Place")
                        .WithOne("User")
                        .HasForeignKey("Entities.User", "PlaceId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Place");
                });

            modelBuilder.Entity("Entities.UserDishes", b =>
                {
                    b.HasOne("Entities.Dish", "Dish")
                        .WithMany("UserDishes")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.User", "User")
                        .WithMany("UserDishes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Dish", b =>
                {
                    b.Navigation("UserDishes");
                });

            modelBuilder.Entity("Entities.Place", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Navigation("UserDishes");
                });
#pragma warning restore 612, 618
        }
    }
}
