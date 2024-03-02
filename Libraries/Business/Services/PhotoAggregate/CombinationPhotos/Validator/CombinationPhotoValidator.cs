using Entities.Concrete.PhotoAggregate;
using FluentValidation;
namespace Business.Services.PhotoAggregate.CombinationPhotos.Validator
{
    public class CreateCombinationPhotoValidator : AbstractValidator<CombinationPhoto>
    {
        public CreateCombinationPhotoValidator()
        {
            RuleFor(x => x.CombinationId).NotEmpty();
            RuleFor(x => x.PhotoId).NotEmpty();
        }
    }
    public class UpdateCombinationPhotoValidator : AbstractValidator<CombinationPhoto>
    {
        public UpdateCombinationPhotoValidator()
        {
            RuleFor(x => x.CombinationId).NotEmpty();
            RuleFor(x => x.PhotoId).NotEmpty();
        }
    }
}