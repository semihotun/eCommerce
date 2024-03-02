using Entities.Concrete.AdressAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DataAccess.FluentApi.AddressAggregate
{
    public class MyUserAdressesMap : IEntityTypeConfiguration<MyUserAdresses>
    {
        public void Configure(EntityTypeBuilder<MyUserAdresses> builder)
        {
            builder.HasIndex(x => x.UserId);
            builder.HasIndex(x => x.AddressId);
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Id).UseIdentityColumn();
        }
    }
}
