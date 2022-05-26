﻿using Core.Library;
using Core.Library.Entities.Concrete;
using Entities.Concrete.AdressAggregate;
using Entities.Concrete.BrandAggregate;
using Entities.Concrete.CategoriesAggregate;
using Entities.Concrete.CommentsAggregate;
using Entities.Concrete.DiscountsAggregate;
using Entities.Concrete.PhotoAggregate;
using Entities.Concrete.ProductAggregate;
using Entities.Concrete.ShowcaseAggregate;
using Entities.Concrete.SliderAggregate;
using Entities.Concrete.SpeficationAggregate;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using System;
using System.Linq;
using System.Reflection;

namespace DataAccess.Context
{
    public class eCommerceContext : CoreContext
    {
       
        private DbContextOptions<eCommerceContext> dbContextOptions;
        protected static DbContextOptions<T> ChangeOptionsType<T>(DbContextOptions options) where T : DbContext
        {
            var sqlExt = options.Extensions.FirstOrDefault(e => e is SqlServerOptionsExtension);

            if (sqlExt == null)
                throw new Exception("Failed to retrieve SQL connection string for base Context");

            return new DbContextOptionsBuilder<T>()
                        .Options;
        }
        public eCommerceContext(DbContextOptions<eCommerceContext> options) : base(ChangeOptionsType<CoreContext>(options))
        {
            dbContextOptions = options;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var sqlServerOptionsExtension = dbContextOptions.
                  FindExtension<SqlServerOptionsExtension>();

            var connectionString = sqlServerOptionsExtension.ConnectionString;
          
            optionsBuilder.UseSqlServer(connectionString);               
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assm = Assembly.GetExecutingAssembly();
            modelBuilder.ApplyConfigurationsFromAssembly(assm);

            base.OnModelCreating(modelBuilder);
        }
        #region DBSets
        public virtual DbSet<ProductLike> ProductLike { get; set; }
        public virtual DbSet<Address> Addres { get; set; }
        public virtual DbSet<ProductShipmentInfo> ProductShipmentInfo { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<CatalogBrand> CatalogBrand { get; set; }
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

        #endregion

      

    }
}




