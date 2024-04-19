using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DataAccess.FluentApi.CategoriesAggregate
{
    public class CategorySpeficationMap : IEntityTypeConfiguration<CategorySpefication>
    {
        public void Configure(EntityTypeBuilder<CategorySpefication> builder)
        {
            builder.HasIndex(x => x.CategoryId);
            builder.HasKey(x => x.Id);
        }
    }
}
