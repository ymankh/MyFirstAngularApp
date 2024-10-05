﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyFirstAngularApp.Server.Models;

#nullable disable

namespace MyFirstAngularApp.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("MyFirstAngularApp.Server.Models.CustomUser", b =>
                {
                    b.Property<int>("CustomUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CustomUserId");

                    b.ToTable("CustomUsers");
                });

            modelBuilder.Entity("MyFirstAngularApp.Server.Models.Service", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ServiceDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("ServiceImage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("ServiceID");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("MyFirstAngularApp.Server.Models.SubService", b =>
                {
                    b.Property<int>("SubServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ServiceID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SubServiceDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("SubServiceImage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SubServiceImagePath")
                        .HasColumnType("TEXT");

                    b.Property<string>("SubServiceName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("SubServiceID");

                    b.HasIndex("ServiceID");

                    b.ToTable("SubServices");
                });

            modelBuilder.Entity("MyFirstAngularApp.Server.Models.SubService", b =>
                {
                    b.HasOne("MyFirstAngularApp.Server.Models.Service", "Service")
                        .WithMany("SubServices")
                        .HasForeignKey("ServiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("MyFirstAngularApp.Server.Models.Service", b =>
                {
                    b.Navigation("SubServices");
                });
#pragma warning restore 612, 618
        }
    }
}
