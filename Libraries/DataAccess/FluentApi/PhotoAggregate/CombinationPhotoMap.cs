using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DataAccess.FluentApi.PhotoAggregate
{
    public class CombinationPhotoMap : IEntityTypeConfiguration<CombinationPhoto>
    {
        public void Configure(EntityTypeBuilder<CombinationPhoto> builder)
        {
            builder.HasIndex(x => x.CombinationId);
            builder.HasIndex(x => x.PhotoId);
            builder.HasKey(x => x.Id);
        }
    }
}
