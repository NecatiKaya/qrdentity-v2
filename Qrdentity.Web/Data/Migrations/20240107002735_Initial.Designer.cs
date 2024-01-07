﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Qrdentity.Web.Data;

#nullable disable

namespace Qrdentity.Web.Data.Migrations
{
    [DbContext(typeof(QrdentityContext))]
    [Migration("20240107002735_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Qrdentity.Web.Data.B2B.BusinessSubType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BusinessTypeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2024, 1, 7, 0, 27, 35, 715, DateTimeKind.Unspecified).AddTicks(390), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<string>("Descriptions")
                        .IsRequired()
                        .HasColumnType("json");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BusinessTypeId");

                    b.HasIndex(new[] { "Name" }, "Unique_Index_Name")
                        .IsUnique();

                    b.ToTable("BusinessSubTypes", "b2b");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.B2B.BusinessType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2024, 1, 7, 0, 27, 35, 715, DateTimeKind.Unspecified).AddTicks(1580), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<string>("Descriptions")
                        .IsRequired()
                        .HasColumnType("json");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "Unique_Index_Name")
                        .IsUnique()
                        .HasDatabaseName("Unique_Index_Name1");

                    b.ToTable("BusinessTypes", "b2b");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.B2B.ContactInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2024, 1, 7, 0, 27, 35, 715, DateTimeKind.Unspecified).AddTicks(2310), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uuid");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Contacts", "b2b");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.B2B.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2024, 1, 7, 0, 27, 35, 715, DateTimeKind.Unspecified).AddTicks(5660), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<int?>("EmployeeCount")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("LongName")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TaxNumber")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<Guid>("TaxOfficeId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TaxOfficeId");

                    b.ToTable("Organizations", "b2b");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.B2B.OrganizationAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2024, 1, 7, 0, 27, 35, 715, DateTimeKind.Unspecified).AddTicks(2950), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<Guid>("DistrictId")
                        .HasColumnType("uuid");

                    b.Property<string>("GoogleMapsLink")
                        .HasColumnType("varchar(500)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.HasIndex("OrganizationId")
                        .IsUnique();

                    b.ToTable("OrganizationAddresses", "b2b");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.B2B.OrganizationAgreement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("AgreementEndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("AgreementStartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2024, 1, 7, 0, 27, 35, 715, DateTimeKind.Unspecified).AddTicks(3690), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<int>("FileLength")
                        .HasColumnType("integer");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("OrganizationAgreements", "b2b");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.B2B.OrganizationBusiness", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BusinessSubTypeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2024, 1, 7, 0, 27, 35, 715, DateTimeKind.Unspecified).AddTicks(4220), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BusinessSubTypeId");

                    b.HasIndex(new[] { "OrganizationId", "BusinessSubTypeId" }, "Unique_Index_OrganizationId_SubType");

                    b.ToTable("OrganizationBusinesses", "b2b");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.Cart.ShoppingCart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2024, 1, 7, 0, 27, 35, 715, DateTimeKind.Unspecified).AddTicks(6410), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsShoppingDone")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("ShoppingCarts", "public");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.Cart.ShoppingCartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2024, 1, 7, 0, 27, 35, 715, DateTimeKind.Unspecified).AddTicks(7110), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<decimal>("ListPriceWithoutVatApplied")
                        .HasColumnType("numeric");

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<decimal>("SalePriceWithoutVatApplied")
                        .HasColumnType("numeric");

                    b.Property<Guid>("ShoppingCartId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("ShoppingCartItems", "public");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.Products.QrProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2024, 1, 7, 0, 27, 35, 715, DateTimeKind.Unspecified).AddTicks(7720), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<string>("Descriptions")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .IsUnicode(true)
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<decimal>("ListPriceWithoutVatApplied")
                        .HasColumnType("numeric");

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("QrFor")
                        .HasColumnType("integer");

                    b.Property<decimal>("SalePriceWithoutVatApplied")
                        .HasColumnType("numeric");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Products", "product");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.Utility.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2024, 1, 7, 0, 27, 35, 715, DateTimeKind.Unspecified).AddTicks(8390), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PlateNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex(new[] { "Name" }, "Unique_Index_Name")
                        .IsUnique()
                        .HasDatabaseName("Unique_Index_Name2");

                    b.ToTable("Cities", "utility");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.Utility.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2024, 1, 7, 0, 27, 35, 715, DateTimeKind.Unspecified).AddTicks(9100), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("SortOrder")
                        .HasColumnType("integer");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "Unique_Index_Name")
                        .IsUnique()
                        .HasDatabaseName("Unique_Index_Name3");

                    b.ToTable("Countries", "utility");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.Utility.District", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2024, 1, 7, 0, 27, 35, 715, DateTimeKind.Unspecified).AddTicks(9550), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Districts", "utility");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.Utility.TaxOffice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2024, 1, 7, 0, 27, 35, 716, DateTimeKind.Unspecified).AddTicks(90), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<Guid>("DistrictId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("OfficeName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PlateNumber")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.Property<int>("SortOrder")
                        .HasColumnType("integer");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("TaxOffices", "utility");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.B2B.BusinessSubType", b =>
                {
                    b.HasOne("Qrdentity.Web.Data.B2B.BusinessType", "BusinessType")
                        .WithMany("SubTypes")
                        .HasForeignKey("BusinessTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusinessType");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.B2B.ContactInformation", b =>
                {
                    b.HasOne("Qrdentity.Web.Data.B2B.Organization", "Company")
                        .WithMany("Contacts")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.B2B.Organization", b =>
                {
                    b.HasOne("Qrdentity.Web.Data.Utility.TaxOffice", "TaxOffice")
                        .WithMany()
                        .HasForeignKey("TaxOfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaxOffice");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.B2B.OrganizationAddress", b =>
                {
                    b.HasOne("Qrdentity.Web.Data.Utility.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Qrdentity.Web.Data.B2B.Organization", "Organization")
                        .WithOne("Address")
                        .HasForeignKey("Qrdentity.Web.Data.B2B.OrganizationAddress", "OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.B2B.OrganizationAgreement", b =>
                {
                    b.HasOne("Qrdentity.Web.Data.B2B.Organization", "Organization")
                        .WithMany("Agreements")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.B2B.OrganizationBusiness", b =>
                {
                    b.HasOne("Qrdentity.Web.Data.B2B.BusinessSubType", "BusinessSubType")
                        .WithMany()
                        .HasForeignKey("BusinessSubTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Qrdentity.Web.Data.B2B.Organization", "Organization")
                        .WithMany("Businesses")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusinessSubType");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.Cart.ShoppingCartItem", b =>
                {
                    b.HasOne("Qrdentity.Web.Data.Products.QrProduct", "Product")
                        .WithMany("ShoppingCartItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Qrdentity.Web.Data.Cart.ShoppingCart", "ShoppingCart")
                        .WithMany("ShoppingCartItems")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.Utility.City", b =>
                {
                    b.HasOne("Qrdentity.Web.Data.Utility.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.Utility.District", b =>
                {
                    b.HasOne("Qrdentity.Web.Data.Utility.City", "City")
                        .WithMany("Districts")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.B2B.BusinessType", b =>
                {
                    b.Navigation("SubTypes");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.B2B.Organization", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Agreements");

                    b.Navigation("Businesses");

                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.Cart.ShoppingCart", b =>
                {
                    b.Navigation("ShoppingCartItems");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.Products.QrProduct", b =>
                {
                    b.Navigation("ShoppingCartItems");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.Utility.City", b =>
                {
                    b.Navigation("Districts");
                });

            modelBuilder.Entity("Qrdentity.Web.Data.Utility.Country", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
