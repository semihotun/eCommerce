using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.FluentApi
{
    public class SpecificationAttributeMap : IEntityTypeConfiguration<SpecificationAttribute>
    {
        public void Configure(EntityTypeBuilder<SpecificationAttribute> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Id).UseSqlServerIdentityColumn();
        }
    }
}
