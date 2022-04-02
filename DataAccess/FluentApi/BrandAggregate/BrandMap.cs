using Core.Utilities.Migration;
using Entities.Concrete.BrandAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.FluentApi.BrandAggregate
{
    public class BrandMap : IEntityTypeConfiguration<Brand>,ISeed<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Id).UseSqlServerIdentityColumn();
        }
        public List<Brand> GetSeedData()
        {
            var data = new List<Brand>()
            {
                new Brand(){ BrandName="Apple" },
                new Brand(){ BrandName="Samsung" }
            };

            return data;
        }
    }
}
