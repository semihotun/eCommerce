using Core.Utilities.Migration;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
namespace DataAccess.FluentApi.BrandAggregate
{
    public class BrandMap : IEntityTypeConfiguration<Brand>, ISeed<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(x => x.Id);
        }
        public List<Brand> GetSeedData()
        {
            return new List<Brand>()
            {
                new(){ Id=Guid.NewGuid(),BrandName="Lc-Waikiki" },
                new(){ Id=Guid.NewGuid(),BrandName="HM" }
            };
        }
    }
}
