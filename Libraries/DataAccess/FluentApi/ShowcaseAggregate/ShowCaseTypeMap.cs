using Core.Utilities.Migration;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
namespace DataAccess.FluentApi.ShowcaseAggregate
{
    public class ShowCaseTypeMap : IEntityTypeConfiguration<ShowCaseType>, ISeed<ShowCaseType>
    {
        public void Configure(EntityTypeBuilder<ShowCaseType> builder)
        {
            builder.HasKey(x => x.Id);
        }
        public List<ShowCaseType> GetSeedData()
        {
            return new List<ShowCaseType>()
            {
               new(){ Id =Guid.Parse("6f9619ff-8b86-d011-b42d-00c04fc964ff"), Type= "Ürün Slider" },
               new(){ Id=Guid.Parse("a920bc9e-58d7-48ca-86e8-d71fa4e71764"), Type= "8'li Ürün" },
               new(){ Id=Guid.Parse("9c8e872b-b98e-491c-bed2-7484dfc26620"),Type= "Yazı" }
            };
        }
    }
}
