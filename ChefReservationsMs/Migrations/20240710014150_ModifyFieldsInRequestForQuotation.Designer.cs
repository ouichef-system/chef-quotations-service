﻿// <auto-generated />
using System;
using System.Collections.Generic;
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
    [Migration("20240710014150_ModifyFieldsInRequestForQuotation")]
    partial class ModifyFieldsInRequestForQuotation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("41d83dd8-0fa8-46ab-8b51-2679009a20db"),
                            CreatedAt = new DateTime(2024, 7, 10, 1, 41, 47, 836, DateTimeKind.Utc).AddTicks(6794),
                            CreatedBy = "jbasalo",
                            Description = "Chef italiano",
                            IsActive = true,
                            Name = "Claudio Paolini",
                            OverallScore = 5.0
                        });
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

                    b.ToTable("CuisineCatalogs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4827d138-5ff1-4714-95a1-414d950aa817"),
                            CreatedAt = new DateTime(2024, 7, 10, 1, 41, 47, 836, DateTimeKind.Utc).AddTicks(8687),
                            CreatedBy = "jbasalo",
                            CuisineName = "Pasta"
                        });
                });

            modelBuilder.Entity("ChefReservationsMs.Features.Chefs.Entities.FoodEntity", b =>
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

                    b.Property<Guid>("CuisineTypeId")
                        .HasColumnType("uuid");

                    b.Property<string>("MealTypes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double?>("Score")
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ChefId");

                    b.HasIndex("CuisineTypeId");

                    b.ToTable("Foods");

                    b.HasData(
                        new
                        {
                            Id = new Guid("13743cf1-650b-4522-91fc-7b7210a71419"),
                            ChefId = new Guid("41d83dd8-0fa8-46ab-8b51-2679009a20db"),
                            CreatedAt = new DateTime(2024, 7, 10, 1, 41, 47, 837, DateTimeKind.Utc).AddTicks(1959),
                            CreatedBy = "jbasalo",
                            CuisineTypeId = new Guid("4827d138-5ff1-4714-95a1-414d950aa817"),
                            MealTypes = "Dinner,Lunch",
                            Name = "Fettucini a la parmessiana",
                            Score = 2.0
                        });
                });

            modelBuilder.Entity("ChefReservationsMs.Features.Quotations.StateMachines.Instances.Quotation", b =>
                {
                    b.Property<Guid>("CorrelationId")
                        .HasColumnType("uuid");

                    b.Property<string>("ChefComments")
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

                    b.Property<decimal>("Price")
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

            modelBuilder.Entity("ChefReservationsMs.Features.RequestQuotations.Aggregate.RequestForQuotation", b =>
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

                    b.Property<List<string>>("CuisinePreferences")
                        .IsRequired()
                        .HasColumnType("text[]");

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

            modelBuilder.Entity("ChefReservationsMs.Features.Chefs.Entities.FoodEntity", b =>
                {
                    b.HasOne("ChefReservationsMs.Features.Chefs.Entities.ChefEntity", "Chef")
                        .WithMany("Foods")
                        .HasForeignKey("ChefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChefReservationsMs.Features.Chefs.Entities.CuisineCatalogEntity", "CuisineType")
                        .WithMany()
                        .HasForeignKey("CuisineTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chef");

                    b.Navigation("CuisineType");
                });

            modelBuilder.Entity("ChefReservationsMs.Features.Quotations.StateMachines.Instances.Quotation", b =>
                {
                    b.HasOne("ChefReservationsMs.Features.RequestQuotations.Aggregate.RequestForQuotation", "RequestForQuotation")
                        .WithMany("Quotations")
                        .HasForeignKey("RequestForQuotationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequestForQuotation");
                });

            modelBuilder.Entity("ChefReservationsMs.Features.Chefs.Entities.ChefEntity", b =>
                {
                    b.Navigation("Foods");
                });

            modelBuilder.Entity("ChefReservationsMs.Features.RequestQuotations.Aggregate.RequestForQuotation", b =>
                {
                    b.Navigation("Quotations");
                });
#pragma warning restore 612, 618
        }
    }
}
