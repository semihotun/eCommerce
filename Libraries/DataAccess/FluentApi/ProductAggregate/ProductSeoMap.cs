using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DataAccess.FluentApi.ProductAggregate
{
    public class ProductSeoMap : IEntityTypeConfiguration<ProductSeo>
    {
        public void Configure(EntityTypeBuilder<ProductSeo> builder)
        {
            builder.HasIndex(x => x.ProductId);
            builder.HasKey(x => x.Id);
        }
    }
}
