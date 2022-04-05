using Entities.Concrete.ShowcaseAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.FluentApi.ShowcaseAggregate
{
    public class ShowCaseMap : IEntityTypeConfiguration<ShowCase>
    {
        public void Configure(EntityTypeBuilder<ShowCase> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Id).UseIdentityColumn();
        }
    }
}



