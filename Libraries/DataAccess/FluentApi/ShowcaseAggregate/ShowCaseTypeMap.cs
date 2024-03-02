using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Migration;
using Entities.Concrete.ShowcaseAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DataAccess.FluentApi.ShowcaseAggregate
{
    public class ShowCaseTypeMap : IEntityTypeConfiguration<ShowCaseType>, ISeed<ShowCaseType>
    {
        public void Configure(EntityTypeBuilder<ShowCaseType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Id).UseIdentityColumn();
        }
        public List<ShowCaseType> GetSeedData()
        {
            return new List<ShowCaseType>()
            {
               new ShowCaseType(){ Type= "Ürün Slider" },
               new ShowCaseType(){ Type= "8'li Ürün" },
               new ShowCaseType(){ Type= "Yazı" }
            };
        }
    }
}
