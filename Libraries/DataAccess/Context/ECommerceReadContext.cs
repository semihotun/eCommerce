using Core.SeedWork;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Context
{
    public class ECommerceReadContext : DbContext
    {
        public ECommerceReadContext(DbContextOptions<ECommerceReadContext> options) : base(options)
        {
        }
        public IQueryable<TEntity> Query<TEntity>() where TEntity : BaseEntity
        {
            return Set<TEntity>().AsQueryable().Where(x => !x.IsDeleted);
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
