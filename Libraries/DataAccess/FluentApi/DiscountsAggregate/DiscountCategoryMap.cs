using Entities.Concrete.DiscountsAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DataAccess.FluentApi.DiscountsAggregate
{
    public class DiscountCategoryMap : IEntityTypeConfiguration<DiscountCategory>
    {
        public void Configure(EntityTypeBuilder<DiscountCategory> builder)
        {
            builder.HasIndex(x => x.CategoryId);
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Id).UseIdentityColumn();
        }
    }
}
