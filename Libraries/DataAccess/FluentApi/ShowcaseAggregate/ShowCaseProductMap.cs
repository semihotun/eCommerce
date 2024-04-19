using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DataAccess.FluentApi.ShowcaseAggregate
{
    public class ShowCaseProductMap : IEntityTypeConfiguration<ShowCaseProduct>
    {
        public void Configure(EntityTypeBuilder<ShowCaseProduct> builder)
        {
            builder.HasIndex(x => new { x.ProductId, x.CombinationId });
            builder.HasKey(x => x.Id);
        }
    }
}
