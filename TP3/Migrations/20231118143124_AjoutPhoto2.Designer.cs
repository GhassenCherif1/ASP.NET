﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP3.Models;

#nullable disable

namespace TP3.Migrations
{
    [DbContext(typeof(TP3Context))]
    [Migration("20231118143124_AjoutPhoto2")]
    partial class AjoutPhoto2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerMovie", b =>
                {
                    b.Property<int>("CustomersId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("CustomersId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("CustomerMovie");
                });

            modelBuilder.Entity("TP3.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MembershipTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MembershipTypeId")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TP3.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 9,
                            GenreName = "Sad"
                        },
                        new
                        {
                            Id = 10,
                            GenreName = "Happy"
                        });
                });

            modelBuilder.Entity("TP3.Models.MembershipType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("DiscountRate")
                        .HasColumnType("real");

                    b.Property<int>("DurationInMonth")
                        .HasColumnType("int");

                    b.Property<float>("SignUpFee")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("MembershipTypes");
                });

            modelBuilder.Entity("TP3.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("genre_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("genre_Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("CustomerMovie", b =>
                {
                    b.HasOne("TP3.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP3.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TP3.Models.Customer", b =>
                {
                    b.HasOne("TP3.Models.MembershipType", "MembershipType")
                        .WithOne("Customer")
                        .HasForeignKey("TP3.Models.Customer", "MembershipTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MembershipType");
                });

            modelBuilder.Entity("TP3.Models.Movie", b =>
                {
                    b.HasOne("TP3.Models.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("genre_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("TP3.Models.Genre", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("TP3.Models.MembershipType", b =>
                {
                    b.Navigation("Customer");
                });
#pragma warning restore 612, 618
        }
    }
}
