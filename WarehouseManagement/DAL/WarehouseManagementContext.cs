using WarehouseManagement.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WarehouseManagement.DAL
{
    public class WarehouseManagementContext : DbContext
    {
        public WarehouseManagementContext() : base("WarehouseManagementContext")
        {
        }

        public DbSet<ProductCategory> productCategories { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Product>()
            .HasRequired(c => c.Group)
            .WithMany()
            .WillCascadeOnDelete(false);

        }

        public System.Data.Entity.DbSet<WarehouseManagement.Models.Company> Companies { get; set; }
    }
}