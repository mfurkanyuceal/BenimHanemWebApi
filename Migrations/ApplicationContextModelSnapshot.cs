﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplication.Models;

namespace WebApplication.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("WebApplication.Models.HomeModel", b =>
                {
                    b.Property<string>("HomeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HomeAddress");

                    b.Property<string>("HomeName")
                        .IsRequired();

                    b.Property<string>("HomePassword")
                        .IsRequired();

                    b.HasKey("HomeID");

                    b.ToTable("HomeModels");
                });

            modelBuilder.Entity("WebApplication.Models.ProductModel", b =>
                {
                    b.Property<string>("ProductID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProductAmount");

                    b.Property<string>("ProductAmountType")
                        .IsRequired();

                    b.Property<string>("ProductFromWhere");

                    b.Property<string>("ProductHomeRefID");

                    b.Property<string>("ProductName")
                        .IsRequired();

                    b.Property<int>("ProductPrice");

                    b.Property<string>("addedByUserName");

                    b.Property<string>("deletedByUserName");

                    b.Property<bool>("isDeleted");

                    b.Property<bool>("isTaken");

                    b.Property<bool>("isUpdated");

                    b.Property<string>("takenByUserName");

                    b.Property<string>("updatedByUserName");

                    b.HasKey("ProductID");

                    b.HasIndex("ProductHomeRefID");

                    b.ToTable("ProductModels");
                });

            modelBuilder.Entity("WebApplication.Models.UserModel", b =>
                {
                    b.Property<string>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserFullName")
                        .IsRequired();

                    b.Property<string>("UserHomeRefID");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.Property<string>("UserPassword")
                        .IsRequired();

                    b.Property<string>("UserPhotoURL");

                    b.HasKey("UserID");

                    b.HasIndex("UserHomeRefID");

                    b.ToTable("UserModels");
                });

            modelBuilder.Entity("WebApplication.Models.ProductModel", b =>
                {
                    b.HasOne("WebApplication.Models.HomeModel", "ProductHomeModel")
                        .WithMany("shoppingList")
                        .HasForeignKey("ProductHomeRefID");
                });

            modelBuilder.Entity("WebApplication.Models.UserModel", b =>
                {
                    b.HasOne("WebApplication.Models.HomeModel", "UserHomeModel")
                        .WithMany("userList")
                        .HasForeignKey("UserHomeRefID");
                });
#pragma warning restore 612, 618
        }
    }
}
