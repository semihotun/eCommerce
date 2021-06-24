using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.FluentApi
{
    public class PredefinedProductAttributeValueMap : IEntityTypeConfiguration<PredefinedProductAttributeValue>
    {
        public void Configure(EntityTypeBuilder<PredefinedProductAttributeValue> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Id).UseSqlServerIdentityColumn();
        }
    }
}
