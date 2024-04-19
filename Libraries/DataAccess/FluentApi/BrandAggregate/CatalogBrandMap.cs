using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DataAccess.FluentApi.BrandAggregate
{
    public class CatalogBrandMap : IEntityTypeConfiguration<CatalogBrand>
    {
        public void Configure(EntityTypeBuilder<CatalogBrand> builder)
        {
            builder.HasIndex(x => x.CategoryId);
            builder.HasKey(x => x.Id);
        }
    }
}
