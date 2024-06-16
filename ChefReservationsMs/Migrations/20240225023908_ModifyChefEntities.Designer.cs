﻿// <auto-generated />
using System;
using ChefReservationsMs.Common_Services.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ChefReservationsMs.Migrations
{
    [DbContext(typeof(ChefReservationsDbContext))]
    [Migration("20240225023908_ModifyChefEntities")]
    partial class ModifyChefEntities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ChefReservationsMs.Features.Chefs.Entities.ChefEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double?>("OverallScore")
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Chefs");
                });

            modelBuilder.Entity("ChefReservationsMs.Features.Chefs.Entities.ChefFoodEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ChefId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("FoodId")
                        .HasColumnType("uuid");

                    b.Property<double?>("Score")
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ChefId");

                    b.HasIndex("FoodId");

                    b.ToTable("ChefFood");
                });

            modelBuilder.Entity("ChefReservationsMs.Features.Chefs.Entities.CuisineCatalogEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CuisineName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CuisinesCatalog");
                });

            modelBuilder.Entity("ChefReservationsMs.Features.Chefs.Entities.FoodEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CuisineTypeId")
                        .HasColumnType("uuid");

                    b.Property<byte[]>("MealTypes")
                        .IsRequired()
                        .HasColumnType("smallint[]");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CuisineTypeId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("ChefReservationsMs.Features.Quotations.StateMachines.Instances.Quotation", b =>
                {
                    b.Property<Guid>("CorrelationId")
                        .HasColumnType("uuid");

                    b.Property<string>("AdditionalComments")
                        .HasColumnType("text");

                    b.Property<Guid>("ChefId")
                        .HasColumnType("uuid");

                    b.Property<string>("ChefName")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CurrentState")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string[]>("Items")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<Guid>("RequestForQuotationId")
                        .HasColumnType("uuid");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("CorrelationId");

                    b.HasIndex("CorrelationId")
                        .IsUnique();

                    b.HasIndex("RequestForQuotationId");

                    b.ToTable("Quotations");
                });

            modelBuilder.Entity("ChefReservationsMs.Features.Quotations.StateMachines.Instances.RequestForQuotation", b =>
                {
                    b.Property<Guid>("CorrelationId")
                        .HasColumnType("uuid");

                    b.Property<string>("AdditionalComments")
                        .HasColumnType("text");

                    b.Property<string>("ChefPreference")
                        .HasColumnType("text");

                    b.Property<string>("ContactEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ContactPhoneNumber")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CuisinePreference")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CurrentState")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("DietaryRestrictions")
                        .HasColumnType("text");

                    b.Property<bool>("HasWorkingOven")
                        .HasColumnType("boolean");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MealType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumberOfBurners")
                        .HasColumnType("integer");

                    b.Property<int>("NumberOfPeople")
                        .HasColumnType("integer");

                    b.Property<string>("OtherCuisinePreference")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("ReservationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea");

                    b.Property<string>("StoveType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("CorrelationId");

                    b.HasIndex("CorrelationId")
                        .IsUnique();

                    b.ToTable("RequestForQuotations");
                });

            modelBuilder.Entity("ChefReservationsMs.Features.Chefs.Entities.ChefFoodEntity", b =>
                {
                    b.HasOne("ChefReservationsMs.Features.Chefs.Entities.ChefEntity", "Chef")
                        .WithMany()
                        .HasForeignKey("ChefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChefReservationsMs.Features.Chefs.Entities.FoodEntity", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chef");

                    b.Navigation("Food");
                });

            modelBuilder.Entity("ChefReservationsMs.Features.Chefs.Entities.FoodEntity", b =>
                {
                    b.HasOne("ChefReservationsMs.Features.Chefs.Entities.CuisineCatalogEntity", "CuisineType")
                        .WithMany()
                        .HasForeignKey("CuisineTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CuisineType");
                });

            modelBuilder.Entity("ChefReservationsMs.Features.Quotations.StateMachines.Instances.Quotation", b =>
                {
                    b.HasOne("ChefReservationsMs.Features.Quotations.StateMachines.Instances.RequestForQuotation", "RequestForQuotation")
                        .WithMany("Quotations")
                        .HasForeignKey("RequestForQuotationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequestForQuotation");
                });

            modelBuilder.Entity("ChefReservationsMs.Features.Quotations.StateMachines.Instances.RequestForQuotation", b =>
                {
                    b.Navigation("Quotations");
                });
#pragma warning restore 612, 618
        }
    }
}
