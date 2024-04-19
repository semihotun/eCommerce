using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DataAccess.FluentApi.ProductAggregate
{
    public class ProductShipmentInfoMap : IEntityTypeConfiguration<ProductShipmentInfo>
    {
        public void Configure(EntityTypeBuilder<ProductShipmentInfo> builder)
        {
            builder.HasIndex(x => x.ProductId);
            builder.HasKey(x => x.Id);
        }
    }
}
