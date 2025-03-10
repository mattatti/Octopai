﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Octopai.Models;

namespace Octopai.Migrations
{
    [DbContext(typeof(CarServiceDBContext))]
    [Migration("20210216133635_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Octopai.Models.CarService", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarModelId")
                        .HasColumnType("int");

                    b.Property<float>("Cost")
                        .HasColumnType("real");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<float>("NetHours")
                        .HasColumnType("real");

                    b.Property<string>("ServiceEndDate")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ServiceName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ServiceStartDate")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ServiceId");

                    b.ToTable("CarServices");
                });

            modelBuilder.Entity("Octopai.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(6)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("LastModifiedDate")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("PhoneNumber1")
                        .HasColumnType("int");

                    b.Property<int>("PhoneNumber2")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(2)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
