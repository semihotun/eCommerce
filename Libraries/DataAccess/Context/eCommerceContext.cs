using Entities.Concrete.AdressAggregate;
using Entities.Concrete.AuthAggregate;
using Entities.Concrete.BrandAggregate;
using Entities.Concrete.CategoriesAggregate;
using Entities.Concrete.CommentsAggregate;
using Entities.Concrete.CustomerUserAggregate;
using Entities.Concrete.PhotoAggregate;
using Entities.Concrete.ProductAggregate;
using Entities.Concrete.ShowcaseAggregate;
using Entities.Concrete.SliderAggregate;
using Entities.Concrete.SpeficationAggregate;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace DataAccess.Context
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assm = Assembly.GetExecutingAssembly();
            modelBuilder.ApplyConfigurationsFromAssembly(assm);
            base.OnModelCreating(modelBuilder);
        }
        #region DBSets
        public DbSet<AdminUser> AdminUser { get; set; }
        public DbSet<ProductLike> ProductLike { get; set; }
        public DbSet<Address> Addres { get; set; }
        public DbSet<ProductShipmentInfo> ProductShipmentInfo { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<CatalogBrand> CatalogBrand { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<PredefinedProductAttributeValue> PredefinedProductAttributeValue { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductAttributeMapping> ProductAttributeMapping { get; set; }
        public DbSet<ProductAttribute> ProductAttribute { get; set; }
        public DbSet<ProductAttributeCombination> ProductAttributeCombination { get; set; }
        public DbSet<ProductAttributeValue> ProductAttributeValue { get; set; }
        public DbSet<ProductPhoto> ProductPhoto { get; set; }
        public DbSet<ProductSeo> ProductSeo { get; set; }
        public DbSet<ShowCase> ShowCase { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<ShowCaseProduct> ShowCaseProduct { get; set; }
        public DbSet<CombinationPhoto> CombinationPhoto { get; set; }
        public DbSet<CategorySpefication> CategorySpefication { get; set; }
        public DbSet<SpecificationAttribute> SpecificationAttribute { get; set; }
        public DbSet<SpecificationAttributeOption> SpecificationAttributeOption { get; set; }
        public DbSet<ProductSpecificationAttribute> ProductSpecificationAttribute { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<ShowCaseType> ShowCaseType { get; set; }
        public DbSet<ProductStock> ProductStock { get; set; }
        public DbSet<ProductStockType> ProductStockType { get; set; }
        public DbSet<CustomerUser> CustomerUser { get; set; }
        #endregion
    }
}
