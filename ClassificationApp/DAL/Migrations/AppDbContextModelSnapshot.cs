﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryValue")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Domain.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyAddress")
                        .HasMaxLength(64);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Domain.CompanyRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyId");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("RoleId");

                    b.ToTable("CompanyRoles");
                });

            modelBuilder.Entity("Domain.Composition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Compositions");
                });

            modelBuilder.Entity("Domain.CompositionHerb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompositionId");

                    b.Property<int>("HerbId");

                    b.Property<int>("UnitOfMeasureId");

                    b.HasKey("Id");

                    b.HasIndex("CompositionId");

                    b.HasIndex("HerbId");

                    b.HasIndex("UnitOfMeasureId");

                    b.ToTable("CompositionHerbs");
                });

            modelBuilder.Entity("Domain.CompositionSubstance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompositionId");

                    b.Property<int>("SubstanceId");

                    b.Property<int>("UnitOfMeasureId");

                    b.HasKey("Id");

                    b.HasIndex("CompositionId");

                    b.HasIndex("SubstanceId");

                    b.HasIndex("UnitOfMeasureId");

                    b.ToTable("CompositionSubstances");
                });

            modelBuilder.Entity("Domain.Description", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DescriptionValue")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Descriptions");
                });

            modelBuilder.Entity("Domain.Dosage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DosageValue")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("Dosages");
                });

            modelBuilder.Entity("Domain.Herb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HerbNameEnglish")
                        .HasMaxLength(64);

                    b.Property<string>("HerbNameEstonian")
                        .HasMaxLength(64);

                    b.Property<string>("HerbNameLatin")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("Herbs");
                });

            modelBuilder.Entity("Domain.HerbForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HerbId");

                    b.Property<int>("PlantFormId");

                    b.HasKey("Id");

                    b.HasIndex("HerbId");

                    b.HasIndex("PlantFormId");

                    b.ToTable("HerbForms");
                });

            modelBuilder.Entity("Domain.HerbMedicinal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HerbFormId");

                    b.Property<int>("HerbId");

                    b.Property<int>("HerbPartId");

                    b.Property<int>("MedicinalDoseId");

                    b.HasKey("Id");

                    b.HasIndex("HerbFormId");

                    b.HasIndex("HerbId");

                    b.HasIndex("HerbPartId");

                    b.HasIndex("MedicinalDoseId");

                    b.ToTable("HerbMedicinals");
                });

            modelBuilder.Entity("Domain.HerbPart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HerbId");

                    b.Property<int>("PlantPartId");

                    b.HasKey("Id");

                    b.HasIndex("HerbId");

                    b.HasIndex("PlantPartId");

                    b.ToTable("HerbParts");
                });

            modelBuilder.Entity("Domain.Identity.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Domain.Identity.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Domain.MedicinalDose", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MedicinalDoseValue")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<int>("UnitOfMeasureId");

                    b.HasKey("Id");

                    b.HasIndex("UnitOfMeasureId");

                    b.ToTable("MedicinalDoses");
                });

            modelBuilder.Entity("Domain.PlantForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PlantFormValueEnglish")
                        .HasMaxLength(64);

                    b.Property<string>("PlantFormValueEstonian")
                        .HasMaxLength(64);

                    b.Property<string>("PlantFormValueLatin")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("PlantForms");
                });

            modelBuilder.Entity("Domain.PlantPart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PlantPartValueEnglish")
                        .HasMaxLength(64);

                    b.Property<string>("PlantPartValueEstonian")
                        .HasMaxLength(64);

                    b.Property<string>("PlantPartValueLatin")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("PlantParts");
                });

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProductClassificationId");

                    b.Property<int>("ProductNameId");

                    b.Property<int>("RouteOfAdministrationId");

                    b.HasKey("Id");

                    b.HasIndex("ProductClassificationId");

                    b.HasIndex("ProductNameId");

                    b.HasIndex("RouteOfAdministrationId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Domain.ProductClassification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProductClassificationValue")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.ToTable("ProductClassifications");
                });

            modelBuilder.Entity("Domain.ProductCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyId");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCompanies");
                });

            modelBuilder.Entity("Domain.ProductComposition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompositionId");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("CompositionId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCompositions");
                });

            modelBuilder.Entity("Domain.ProductDescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DescriptionId");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("DescriptionId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductDescriptions");
                });

            modelBuilder.Entity("Domain.ProductDosage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DosageId");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("DosageId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductDosages");
                });

            modelBuilder.Entity("Domain.ProductName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProductNameValue")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("ProductNames");
                });

            modelBuilder.Entity("Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoleValue")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Domain.RouteOfAdministration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RouteOfAdministrationValue")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("RouteOfAdministrations");
                });

            modelBuilder.Entity("Domain.Substance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SubstanceName")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("Substances");
                });

            modelBuilder.Entity("Domain.SubstanceCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<int>("SubstanceId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SubstanceId");

                    b.ToTable("SubstanceCategories");
                });

            modelBuilder.Entity("Domain.SubstanceMedicinal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MedicinalDoseId");

                    b.Property<int>("SubstanceId");

                    b.HasKey("Id");

                    b.HasIndex("MedicinalDoseId");

                    b.HasIndex("SubstanceId");

                    b.ToTable("SubstanceMedicinals");
                });

            modelBuilder.Entity("Domain.UnitOfMeasure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UnitOfMeasureValue")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.ToTable("UnitOfMeasures");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Domain.CompanyRole", b =>
                {
                    b.HasOne("Domain.Company", "Company")
                        .WithMany("CompanyRoles")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Role", "Role")
                        .WithMany("CompanyRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.CompositionHerb", b =>
                {
                    b.HasOne("Domain.Composition", "Composition")
                        .WithMany("CompositionHerbs")
                        .HasForeignKey("CompositionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Herb", "Herb")
                        .WithMany("CompositionHerbs")
                        .HasForeignKey("HerbId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.UnitOfMeasure", "UnitOfMeasure")
                        .WithMany("CompositionHerbs")
                        .HasForeignKey("UnitOfMeasureId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.CompositionSubstance", b =>
                {
                    b.HasOne("Domain.Composition", "Composition")
                        .WithMany("CompositionSubstances")
                        .HasForeignKey("CompositionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Substance", "Substance")
                        .WithMany("CompositionSubstances")
                        .HasForeignKey("SubstanceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.UnitOfMeasure", "UnitOfMeasure")
                        .WithMany("CompositionSubstances")
                        .HasForeignKey("UnitOfMeasureId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.HerbForm", b =>
                {
                    b.HasOne("Domain.Herb", "Herb")
                        .WithMany("HerbForms")
                        .HasForeignKey("HerbId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.PlantForm", "PlantForm")
                        .WithMany("HerbForms")
                        .HasForeignKey("PlantFormId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.HerbMedicinal", b =>
                {
                    b.HasOne("Domain.HerbForm", "HerbForm")
                        .WithMany("HerbMedicinals")
                        .HasForeignKey("HerbFormId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Herb", "Herb")
                        .WithMany("HerbMedicinals")
                        .HasForeignKey("HerbId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.HerbPart", "HerbPart")
                        .WithMany("HerbMedicinals")
                        .HasForeignKey("HerbPartId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.MedicinalDose", "MedicinalDose")
                        .WithMany("HerbMedicinals")
                        .HasForeignKey("MedicinalDoseId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.HerbPart", b =>
                {
                    b.HasOne("Domain.Herb", "Herb")
                        .WithMany("HerbParts")
                        .HasForeignKey("HerbId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.PlantPart", "PlantPart")
                        .WithMany("HerbParts")
                        .HasForeignKey("PlantPartId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.MedicinalDose", b =>
                {
                    b.HasOne("Domain.UnitOfMeasure", "UnitOfMeasure")
                        .WithMany("MedicinalDoses")
                        .HasForeignKey("UnitOfMeasureId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.HasOne("Domain.ProductClassification", "ProductClassification")
                        .WithMany("Products")
                        .HasForeignKey("ProductClassificationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.ProductName", "ProductName")
                        .WithMany("Products")
                        .HasForeignKey("ProductNameId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.RouteOfAdministration", "RouteOfAdministration")
                        .WithMany("Products")
                        .HasForeignKey("RouteOfAdministrationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.ProductCompany", b =>
                {
                    b.HasOne("Domain.Company", "Company")
                        .WithMany("ProductCompanies")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Product", "Product")
                        .WithMany("ProductCompanies")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.ProductComposition", b =>
                {
                    b.HasOne("Domain.Composition", "Composition")
                        .WithMany("ProductCompositions")
                        .HasForeignKey("CompositionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Product", "Product")
                        .WithMany("ProductCompositions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.ProductDescription", b =>
                {
                    b.HasOne("Domain.Description", "Description")
                        .WithMany("ProductDescriptions")
                        .HasForeignKey("DescriptionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Product", "Product")
                        .WithMany("ProductDescriptions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.ProductDosage", b =>
                {
                    b.HasOne("Domain.Dosage", "Dosage")
                        .WithMany("ProductDosages")
                        .HasForeignKey("DosageId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Product", "Product")
                        .WithMany("ProductDosages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.SubstanceCategory", b =>
                {
                    b.HasOne("Domain.Category", "Category")
                        .WithMany("SubstanceCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Substance", "Substance")
                        .WithMany("SubstanceCategories")
                        .HasForeignKey("SubstanceId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.SubstanceMedicinal", b =>
                {
                    b.HasOne("Domain.MedicinalDose", "MedicinalDose")
                        .WithMany("SubstanceMedicinals")
                        .HasForeignKey("MedicinalDoseId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Substance", "Substance")
                        .WithMany("SubstanceMedicinals")
                        .HasForeignKey("SubstanceId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Domain.Identity.AppRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Domain.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Domain.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Domain.Identity.AppRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Domain.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
