using Core.Utilities.Migration;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace DataAccess.FluentApi.AuthAggregate
{
    public class RoleMap : IEntityTypeConfiguration<Role>, ISeed<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
        }
        public List<Role> GetSeedData()
        {
            return new List<Role>()
            {
                new(){ RoleName="Admin" },
                new(){ RoleName="User" }
            };
        }
    }
}
