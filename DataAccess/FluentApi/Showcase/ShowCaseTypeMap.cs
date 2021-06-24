using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.FluentApi.Showcase
{
    public class ShowCaseTypeMap : IEntityTypeConfiguration<ShowCaseType>
    {
        public void Configure(EntityTypeBuilder<ShowCaseType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Id).UseSqlServerIdentityColumn();
        }
    }
}
