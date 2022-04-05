using Entities.Concrete.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.FluentApi.ProductAggregate
{
    public class ProductStockTypeMap : IEntityTypeConfiguration<ProductStockType>
    {
        public void Configure(EntityTypeBuilder<ProductStockType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Id).UseIdentityColumn();
        }
    }
}
