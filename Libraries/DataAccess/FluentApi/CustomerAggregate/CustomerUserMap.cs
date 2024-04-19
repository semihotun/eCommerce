using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.FluentApi.CustomerAggregate
{
    public class CustomerUserMap : IEntityTypeConfiguration<CustomerUser>
    {
        public void Configure(EntityTypeBuilder<CustomerUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable(nameof(CustomerUser));
        }
    }
}
