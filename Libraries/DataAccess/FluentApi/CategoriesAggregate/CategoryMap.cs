using Core.Utilities.Migration;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
namespace DataAccess.FluentApi.CategoriesAggregate
{
    public class CategoryMap : IEntityTypeConfiguration<Category>, ISeed<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
        }

        public List<Category> GetSeedData()
        {
            return new List<Category>
            {
                new()
                {
                    Id=Guid.Parse("f9290583-f09a-4cde-920d-f54eab68bbc6"),
                    CategoryName="Kıyafet",
                    IsDeleted=false,
                    ParentCategoryId=Guid.Empty
                },
                new()
                {
                    Id=Guid.NewGuid(),
                    CategoryName="Elbise",
                    IsDeleted=false,
                    ParentCategoryId=Guid.Parse("f9290583-f09a-4cde-920d-f54eab68bbc6")
                },
                new()
                {
                    Id=Guid.NewGuid(),
                    CategoryName="T-Shirt",
                    IsDeleted=false,
                    ParentCategoryId=Guid.Parse("f9290583-f09a-4cde-920d-f54eab68bbc6")
                }
            };
        }
    }
}
