using Entities.Concrete.SpeficationAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DataAccess.FluentApi.SpeficationAggregate
{
    public class SpecificationAttributeOptionMap : IEntityTypeConfiguration<SpecificationAttributeOption>
    {
        public void Configure(EntityTypeBuilder<SpecificationAttributeOption> builder)
        {
            builder.HasIndex(x => x.SpecificationAttributeId);
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Id).UseIdentityColumn();
        }
    }
}
