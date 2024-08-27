﻿// <auto-generated />
using System;
using BSVEFCore.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BSVEFCore.Migrations
{
    [DbContext(typeof(BSVDBContext))]
    partial class BSVDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BSVEFCore.Models.Department", b =>
                {
                    b.Property<Guid>("D_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("D_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("D_Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("BSVEFCore.Models.Employee", b =>
                {
                    b.Property<Guid>("E_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("D_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("E_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("E_Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("E_Id");

                    b.HasIndex("D_Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("BSVEFCore.Models.Employee", b =>
                {
                    b.HasOne("BSVEFCore.Models.Department", "Departments")
                        .WithMany("Employees")
                        .HasForeignKey("D_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departments");
                });

            modelBuilder.Entity("BSVEFCore.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
