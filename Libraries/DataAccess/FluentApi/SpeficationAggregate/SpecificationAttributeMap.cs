using Core.Utilities.Migration;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
namespace DataAccess.FluentApi.SpeficationAggregate
{
    public class SpecificationAttributeMap : IEntityTypeConfiguration<SpecificationAttribute>, ISeed<SpecificationAttribute>
    {
        public void Configure(EntityTypeBuilder<SpecificationAttribute> builder)
        {
            builder.HasKey(x => x.Id);
        }
        public List<SpecificationAttribute> GetSeedData()
        {
            return new List<SpecificationAttribute>
            {
                new ()
                {
                    Id=Guid.Parse("5988761d-9ef6-43f6-b6a9-7e5c30fba774"),
                    DisplayOrder =0,
                    IsDeleted=false,
                    Name="Renk"
                },
                  new ()
                {
                    Id=Guid.Parse("830e13ee-6b4b-476a-b8aa-51f3bd52ced9"),
                    DisplayOrder =0,
                    IsDeleted=false,
                    Name="Boyut"
                }
            };
        }
    }
}
