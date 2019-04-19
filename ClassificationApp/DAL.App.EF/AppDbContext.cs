using System.Linq;
using Contracts.DAL.Base;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Dosage> Dosages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductClassification> ProductClassifications { get; set; }
        public DbSet<ProductCompany> ProductCompanies { get; set; }
        public DbSet<ProductComposition> ProductCompositions { get; set; }
        public DbSet<ProductDescription> ProductDescriptions { get; set; }
        public DbSet<ProductDosage> ProductDosages { get; set; }
        public DbSet<ProductName> ProductNames { get; set; }
        public DbSet<RouteOfAdministration> RouteOfAdministrations { get; set; }

        public DbSet<Company> Companies { get; set; }
        public DbSet<CRole> CRoles { get; set; }
        public DbSet<CompanyRole> CompanyRoles { get; set; }
        public DbSet<Composition> Compositions { get; set; }
        public DbSet<CompositionHerb> CompositionHerbs { get; set; }
        public DbSet<CompositionSubstance> CompositionSubstances { get; set; }

        public DbSet<Herb> Herbs { get; set; }
        public DbSet<HerbForm> HerbForms { get; set; }
        public DbSet<HerbMedicinal> HerbMedicinals { get; set; }
        public DbSet<HerbPart> HerbParts { get; set; }
        public DbSet<PlantForm> PlantForms { get; set; }
        public DbSet<PlantPart> PlantParts { get; set; }
        public DbSet<MedicinalDose> MedicinalDoses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Substance> Substances { get; set; }
        public DbSet<SubstanceCategory> SubstanceCategories { get; set; }
        public DbSet<SubstanceMedicinal> SubstanceMedicinals { get; set; }
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