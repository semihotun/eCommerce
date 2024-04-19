using Core.Utilities.Migration;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
namespace DataAccess.FluentApi.ProductAggregate
{
    public class ProductAttributeMap : IEntityTypeConfiguration<ProductAttribute>, ISeed<ProductAttribute>
    {
        public void Configure(EntityTypeBuilder<ProductAttribute> builder)
        {
            builder.HasKey(x => x.Id);
        }

        public List<ProductAttribute> GetSeedData()
        {
            return new List<ProductAttribute>{
                new ()
                {
                    Id = Guid.NewGuid(),
                    Description="Ürün Rengi",
                    Name="Renk",
                    IsDeleted=false
                },
                new ()
                {
                    Id = Guid.NewGuid(),
                    Description="Ürün Boyutu",
                    Name="Boyut",
                    IsDeleted=false
                }
            };
        }
    }
}
