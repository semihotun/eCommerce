using Entities.Concrete.DiscountsAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
namespace DataAccess.FluentApi.DiscountsAggregate
{
    public class DiscountUsageHistoryMap : IEntityTypeConfiguration<DiscountUsageHistory>
    {
        public void Configure(EntityTypeBuilder<DiscountUsageHistory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Id).UseIdentityColumn();
        }
    }
}
