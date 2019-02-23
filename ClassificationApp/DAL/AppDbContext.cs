using System;
using System.Linq;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductClassification> ProductClassifications { get; set; }
        public DbSet<ProductComposition> ProductCompositions { get; set; }
        public DbSet<ProductDescription> ProductDescriptions { get; set; }
        public DbSet<ProductDosage> ProductDosages { get; set; }
        public DbSet<ProductName> ProductNames { get; set; }
        public DbSet<RouteOfAdministration> RouteOfAdministrations { get; set; }

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyRole> CompanyRoles { get; set; }

        public DbSet<Herb> Herbs { get; set; }
        public DbSet<HerbForm> HerbForms { get; set; }
        public DbSet<HerbPart> HerbParts { get; set; }
        public DbSet<MedicinalDose> MedicinalDoses { get; set; }
        public DbSet<Substance> Substances { get; set; }
        public DbSet<SubstanceCategory> SubstanceCategories { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}