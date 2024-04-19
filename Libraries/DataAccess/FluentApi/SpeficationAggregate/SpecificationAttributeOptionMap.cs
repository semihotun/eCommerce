using Core.Utilities.Migration;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
namespace DataAccess.FluentApi.SpeficationAggregate
{
    public class SpecificationAttributeOptionMap : IEntityTypeConfiguration<SpecificationAttributeOption>, ISeed<SpecificationAttributeOption>
    {
        public void Configure(EntityTypeBuilder<SpecificationAttributeOption> builder)
        {
            builder.HasIndex(x => x.SpecificationAttributeId);
            builder.HasKey(x => x.Id);
        }

        public List<SpecificationAttributeOption> GetSeedData()
        {
            return new List<SpecificationAttributeOption>(){
                 new (){
                     Id=Guid.NewGuid(),
                     DisplayOrder=0,
                     IsDeleted=false,
                     Name="Kırmızı",
                     SpecificationAttributeId=Guid.Parse("5988761d-9ef6-43f6-b6a9-7e5c30fba774")
                 },
                 new (){
                     Id=Guid.NewGuid(),
                     DisplayOrder=0,
                     IsDeleted=false,
                     Name="Yeşil",
                     SpecificationAttributeId=Guid.Parse("5988761d-9ef6-43f6-b6a9-7e5c30fba774")
                 },
                 new (){
                     Id=Guid.NewGuid(),
                     DisplayOrder=0,
                     IsDeleted=false,
                     Name="L",
                     SpecificationAttributeId=Guid.Parse("830e13ee-6b4b-476a-b8aa-51f3bd52ced9")
                 },
                 new (){
                     Id=Guid.NewGuid(),
                     DisplayOrder=0,
                     IsDeleted=false,
                     Name="XL",
                     SpecificationAttributeId=Guid.Parse("830e13ee-6b4b-476a-b8aa-51f3bd52ced9")
                 }
            };
        }
    }
}
