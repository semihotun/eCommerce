using Entities.Concrete.PhotoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
namespace DataAccess.FluentApi.PhotoAggregate
{
    public class CombinationPhotoMap : IEntityTypeConfiguration<CombinationPhoto>
    {
        public void Configure(EntityTypeBuilder<CombinationPhoto> builder)
        {
            builder.HasIndex(x => x.CombinationId);
            builder.HasIndex(x => x.PhotoId);
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Id).UseIdentityColumn();
        }
    }
}
