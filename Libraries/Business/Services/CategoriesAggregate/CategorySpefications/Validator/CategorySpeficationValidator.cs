using Entities.Concrete.CategoriesAggregate;
using FluentValidation;
namespace Business.Services.CategoriesAggregate.CategorySpefications.Validator
{
    public class CreateCategorySpeficationValidator : AbstractValidator<CategorySpefication>
    {
        public CreateCategorySpeficationValidator()
        {
        }
    }
    public class UpdateCategorySpeficationValidator : AbstractValidator<CategorySpefication>
    {
        public UpdateCategorySpeficationValidator()
        {
        }
    }
}