﻿// <auto-generated />
using CS_Owned_Types.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CS_Owned_Types.Migrations
{
    [DbContext(typeof(PersonalInformationDB))]
    [Migration("20220320064018_firstMigration")]
    partial class firstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CS_Owned_Types.Models.Country", b =>
                {
                    b.Property<string>("CountryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("CS_Owned_Types.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"), 1L, 1);

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("CS_Owned_Types.Models.Person", b =>
                {
                    b.OwnsOne("CS_Owned_Types.Models.Address", "CurrentAddress", b1 =>
                        {
                            b1.Property<int>("PersonId")
                                .HasColumnType("int");

                            b1.Property<string>("Details")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("HouseNo")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Society")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PersonId");

                            b1.ToTable("Persons");

                            b1.WithOwner()
                                .HasForeignKey("PersonId");

                            b1.OwnsOne("CS_Owned_Types.Models.Region", "Region", b2 =>
                                {
                                    b2.Property<int>("AddressPersonId")
                                        .HasColumnType("int");

                                    b2.Property<string>("City")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("CountryId")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(450)");

                                    b2.Property<string>("District")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<int>("RegionId")
                                        .HasColumnType("int");

                                    b2.Property<string>("State")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("AddressPersonId");

                                    b2.HasIndex("CountryId");

                                    b2.ToTable("Persons");

                                    b2.WithOwner()
                                        .HasForeignKey("AddressPersonId");

                                    b2.HasOne("CS_Owned_Types.Models.Country", "Country")
                                        .WithMany()
                                        .HasForeignKey("CountryId")
                                        .OnDelete(DeleteBehavior.Cascade)
                                        .IsRequired();

                                    b2.Navigation("Country");
                                });

                            b1.Navigation("Region")
                                .IsRequired();
                        });

                    b.OwnsOne("CS_Owned_Types.Models.Address", "PermanentAddress", b1 =>
                        {
                            b1.Property<int>("PersonId")
                                .HasColumnType("int");

                            b1.Property<string>("Details")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("HouseNo")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Society")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PersonId");

                            b1.ToTable("Region", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("PersonId");

                            b1.OwnsOne("CS_Owned_Types.Models.Region", "Region", b2 =>
                                {
                                    b2.Property<int>("AddressPersonId")
                                        .HasColumnType("int");

                                    b2.Property<string>("City")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("CountryId")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(450)");

                                    b2.Property<string>("District")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<int>("RegionId")
                                        .HasColumnType("int");

                                    b2.Property<string>("State")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("AddressPersonId");

                                    b2.HasIndex("CountryId");

                                    b2.ToTable("Region");

                                    b2.WithOwner()
                                        .HasForeignKey("AddressPersonId");

                                    b2.HasOne("CS_Owned_Types.Models.Country", "Country")
                                        .WithMany()
                                        .HasForeignKey("CountryId")
                                        .OnDelete(DeleteBehavior.Cascade)
                                        .IsRequired();

                                    b2.Navigation("Country");
                                });

                            b1.Navigation("Region")
                                .IsRequired();
                        });

                    b.Navigation("CurrentAddress")
                        .IsRequired();

                    b.Navigation("PermanentAddress")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}