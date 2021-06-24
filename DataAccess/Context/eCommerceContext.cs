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

namespace DataAccess.Concrete.EntityFramework
{

    public class eCommerceContext : IdentityDbContext<MyUser, MyRole, int, MyClaim, MyUserRole, MyLogin, MyRoleClaim, MyUserToken>
    {

        public eCommerceContext(DbContextOptions<eCommerceContext> options): base()
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

            //modelBuilder.ApplyConfiguration(new BrandMap());
            //modelBuilder.ApplyConfiguration(new CategoryMap());
            //modelBuilder.ApplyConfiguration(new PredefinedProductAttributeValueMap());
            //modelBuilder.ApplyConfiguration(new ProductMap());
            //modelBuilder.ApplyConfiguration(new ProductAttributeMap());
            //modelBuilder.ApplyConfiguration(new ProductAttributeMap());
            //modelBuilder.ApplyConfiguration(new ProductAttributeCombinationMap());
            //modelBuilder.ApplyConfiguration(new ProductAttributeValueMap());
            //modelBuilder.ApplyConfiguration(new ProductPhotoMap());
            //modelBuilder.ApplyConfiguration(new ProductSeoMap());
            //modelBuilder.ApplyConfiguration(new ShoppingCartMap());
            //modelBuilder.ApplyConfiguration(new ShowCaseMap());
            //modelBuilder.ApplyConfiguration(new SliderMap());
            //modelBuilder.ApplyConfiguration(new ShowCaseProductMap());
            //modelBuilder.ApplyConfiguration(new CombinationPhotoMap());
            //modelBuilder.ApplyConfiguration(new CategorySpeficationMap());
            //modelBuilder.ApplyConfiguration(new SpecificationAttributeMap());
            //modelBuilder.ApplyConfiguration(new SpecificationAttributeOptionMap());
            //modelBuilder.ApplyConfiguration(new ProductSpecificationAttributeMap());
            //modelBuilder.ApplyConfiguration(new DiscountMap());
            //modelBuilder.ApplyConfiguration(new DiscountProductMap());
            //modelBuilder.ApplyConfiguration(new DiscountBrandMap());
            //modelBuilder.ApplyConfiguration(new DiscountCategoryMap());
            //modelBuilder.ApplyConfiguration(new DiscountUsageHistoryMap());
            //modelBuilder.ApplyConfiguration(new MyUserMap());
            //modelBuilder.ApplyConfiguration(new MyUserRoleMap());
            //modelBuilder.ApplyConfiguration(new MyRoleMap());
            //modelBuilder.ApplyConfiguration(new MyClaimMap());
            //modelBuilder.ApplyConfiguration(new MyLoginMap());
            //modelBuilder.ApplyConfiguration(new MyRoleClaimMap());
            //modelBuilder.ApplyConfiguration(new MyUserTokenMap());

            //base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}





