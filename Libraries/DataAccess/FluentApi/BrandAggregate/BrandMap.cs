using Core.Utilities.Migration;
using Entities.Concrete.BrandAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
namespace DataAccess.FluentApi.BrandAggregate
{
    public class BrandMap : IEntityTypeConfiguration<Brand>, ISeed<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Id).UseIdentityColumn();
        }
        public List<Brand> GetSeedData()
        {
            return new List<Brand>()
            {
                new(){ BrandName="Apple" },
                new(){ BrandName="Samsung" }
            };
        }
    }
}
