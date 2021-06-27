using Core.Utilities.Interceptors;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Core.Library;

namespace DataAccess.Concrete.EntityFramework
{

    public class eCommerceContext : CoreContext
    {
        protected static DbContextOptions<T> ChangeOptionsType<T>(DbContextOptions options) where T : DbContext
        {
            var sqlExt = options.Extensions.FirstOrDefault(e => e is SqlServerOptionsExtension);

            if (sqlExt == null)
                throw (new Exception("Failed to retrieve SQL connection string for base Context"));

            return new DbContextOptionsBuilder<T>()
                        .UseSqlServer(((SqlServerOptionsExtension)sqlExt).ConnectionString)
                        .Options;
        }
        public eCommerceContext(DbContextOptions<eCommerceContext> options) : base(ChangeOptionsType<CoreContext>(options))
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=DESKTOP-OB76QRL\\SQLEXPRESS;initial catalog=eCommerce;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
        }

        public virtual DbSet<ProductShipmentInfo> ProductShipmentInfo { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<PredefinedProductAttributeValue> PredefinedProductAttributeValue { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductAttributeMapping> ProductAttributeMapping { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttribute { get; set; }
        public virtual DbSet<ProductAttributeCombination> ProductAttributeCombination { get; set; }
        public virtual DbSet<ProductAttributeValue> ProductAttributeValue { get; set; }
        public virtual DbSet<ProductPhoto> ProductPhoto { get; set; }
        public virtual DbSet<ProductSeo> ProductSeo { get; set; }
        public virtual DbSet<ShowCase> ShowCase { get; set; }
        public virtual DbSet<Slider> Slider { get; set; }
        public virtual DbSet<ShowCaseProduct> ShowCaseProduct { get; set; }
        public virtual DbSet<CombinationPhoto> CombinationPhoto { get; set; }
        public virtual DbSet<CategorySpefication> CategorySpefication { get; set; }
        public virtual DbSet<SpecificationAttribute> SpecificationAttribute { get; set; }
        public virtual DbSet<SpecificationAttributeOption> SpecificationAttributeOption { get; set; }
        public virtual DbSet<ProductSpecificationAttribute> ProductSpecificationAttribute { get; set; }
        public virtual DbSet<Discount> Discount { get; set; }
        public virtual DbSet<DiscountProduct> DiscountProduct { get; set; }
        public virtual DbSet<DiscountBrand> DiscountBrand { get; set; }
        public virtual DbSet<DiscountCategory> DiscountCategory { get; set; }
        public virtual DbSet<DiscountUsageHistory> DiscountUsageHistory { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<ShowCaseType> ShowCaseType { get; set; }
        public virtual DbSet<ProductStock> ProductStock { get; set; }
        public virtual DbSet<ProductStockType> ProductStockType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MyUser>()
                .ToTable("Users");

            modelBuilder.Entity<MyRole>()
                .ToTable("Role");

            modelBuilder.Entity<MyUserRole>()
                .ToTable("UserRole");

            modelBuilder.Entity<MyClaim>()
                .ToTable("Claim");

            modelBuilder.Entity<MyLogin>()
                .ToTable("Login");

            modelBuilder.Entity<MyUser>().Property(r => r.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<MyRole>().Property(r => r.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<MyClaim>().Property(r => r.Id).ValueGeneratedOnAdd();

        }

    }
}





