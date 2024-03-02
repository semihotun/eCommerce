using Entities.Concrete.PhotoAggregate;
using FluentValidation;
namespace Business.Services.PhotoAggregate.ProductPhotos.Validator
{
    public class CreateProductPhotoValidator : AbstractValidator<ProductPhoto>
    {
        public CreateProductPhotoValidator()
        {
            RuleFor(x => x.ProductPhotoName).NotEmpty();
        }
    }
    public class UpdateProductPhotoValidator : AbstractValidator<ProductPhoto>
    {
        public UpdateProductPhotoValidator()
        {
            RuleFor(x => x.ProductPhotoName).NotEmpty();
        }
    }
}