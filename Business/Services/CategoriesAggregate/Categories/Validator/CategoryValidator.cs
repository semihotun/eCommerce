using Entities.Concrete.CategoriesAggregate;
using FluentValidation;

namespace Business.Services.CategoriesAggregate.Categories.Validator
{

    public class CreateCategoryValidator : AbstractValidator<Category>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty();

        }
    }
    public class UpdateCategoryValidator : AbstractValidator<Category>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty();

        }
    }
}