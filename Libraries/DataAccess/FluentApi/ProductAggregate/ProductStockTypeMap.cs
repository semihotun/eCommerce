using Core.Utilities.Migration;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
namespace DataAccess.FluentApi.ProductAggregate
{
    public class ProductStockTypeMap : IEntityTypeConfiguration<ProductStockType>, ISeed<ProductStockType>
    {
        public void Configure(EntityTypeBuilder<ProductStockType> builder)
        {
            builder.HasKey(x => x.Id);
        }
        public List<ProductStockType> GetSeedData()
        {
            return new List<ProductStockType>()
            {
                new(){Name="Ürün Stoğundan Eksilt"},
                new(){Name="Varyasyon Stoğundan Eksilt"}
            };
        }
    }
}
