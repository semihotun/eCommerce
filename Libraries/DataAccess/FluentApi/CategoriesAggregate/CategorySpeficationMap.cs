﻿using Entities.Concrete.CategoriesAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.FluentApi.CategoriesAggregate
{
    public class CategorySpeficationMap : IEntityTypeConfiguration<CategorySpefication>
    {
        public void Configure(EntityTypeBuilder<CategorySpefication> builder)
        {
            builder.HasIndex(x => x.CategoryId);

            builder.HasKey(x => x.Id);
            builder.Property(t => t.Id).UseIdentityColumn();
        }
    }
}
