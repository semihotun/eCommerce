﻿using Entities.Concrete.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DataAccess.FluentApi.ProductAggregate
{
    public class PredefinedProductAttributeValueMap : IEntityTypeConfiguration<PredefinedProductAttributeValue>
    {
        public void Configure(EntityTypeBuilder<PredefinedProductAttributeValue> builder)
        {
            builder.HasIndex(x => x.ProductAttributeId);
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Id).UseIdentityColumn();
        }
    }
}
