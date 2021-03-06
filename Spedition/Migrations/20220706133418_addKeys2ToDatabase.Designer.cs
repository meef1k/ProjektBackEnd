// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Spedition.Data;

namespace Spedition.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220706133418_addKeys2ToDatabase")]
    partial class addKeys2ToDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Spedition.Models.Driver", b =>
                {
                    b.Property<int>("id_driver")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Driverid_driver")
                        .HasColumnType("int");

                    b.Property<string>("driver_city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("driver_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("driver_phone")
                        .HasColumnType("int");

                    b.HasKey("id_driver");

                    b.HasIndex("Driverid_driver");

                    b.ToTable("Driver");
                });

            modelBuilder.Entity("Spedition.Models.Speditions", b =>
                {
                    b.Property<int>("id_spedition")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<int>("TrailerId")
                        .HasColumnType("int");

                    b.Property<int>("TruckId")
                        .HasColumnType("int");

                    b.Property<string>("end_place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("start_place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_spedition");

                    b.HasIndex("DriverId");

                    b.HasIndex("TrailerId");

                    b.HasIndex("TruckId");

                    b.ToTable("Speditions");
                });

            modelBuilder.Entity("Spedition.Models.Trailer", b =>
                {
                    b.Property<int>("id_trailer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Trailerid_trailer")
                        .HasColumnType("int");

                    b.Property<string>("trailer_manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("trailer_model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("trailer_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("trailer_plate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_trailer");

                    b.HasIndex("Trailerid_trailer");

                    b.ToTable("Trailer");
                });

            modelBuilder.Entity("Spedition.Models.Truck", b =>
                {
                    b.Property<int>("id_truck")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Truckid_truck")
                        .HasColumnType("int");

                    b.Property<string>("truck_manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("truck_model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("truck_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("truck_plate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_truck");

                    b.HasIndex("Truckid_truck");

                    b.ToTable("Truck");
                });

            modelBuilder.Entity("Spedition.Models.Driver", b =>
                {
                    b.HasOne("Spedition.Models.Driver", null)
                        .WithMany("Drivers")
                        .HasForeignKey("Driverid_driver");
                });

            modelBuilder.Entity("Spedition.Models.Speditions", b =>
                {
                    b.HasOne("Spedition.Models.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Spedition.Models.Trailer", "Trailer")
                        .WithMany()
                        .HasForeignKey("TrailerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Spedition.Models.Truck", "Truck")
                        .WithMany()
                        .HasForeignKey("TruckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Trailer");

                    b.Navigation("Truck");
                });

            modelBuilder.Entity("Spedition.Models.Trailer", b =>
                {
                    b.HasOne("Spedition.Models.Trailer", null)
                        .WithMany("Trailers")
                        .HasForeignKey("Trailerid_trailer");
                });

            modelBuilder.Entity("Spedition.Models.Truck", b =>
                {
                    b.HasOne("Spedition.Models.Truck", null)
                        .WithMany("Trucks")
                        .HasForeignKey("Truckid_truck");
                });

            modelBuilder.Entity("Spedition.Models.Driver", b =>
                {
                    b.Navigation("Drivers");
                });

            modelBuilder.Entity("Spedition.Models.Trailer", b =>
                {
                    b.Navigation("Trailers");
                });

            modelBuilder.Entity("Spedition.Models.Truck", b =>
                {
                    b.Navigation("Trucks");
                });
#pragma warning restore 612, 618
        }
    }
}
