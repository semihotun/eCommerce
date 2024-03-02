using Entities.Concrete.ShowcaseAggregate;
using FluentValidation;
namespace Business.Services.ShowcaseAggregate.ShowcaseTypes.Validator
{
    public class CreateShowCaseTypeValidator : AbstractValidator<ShowCaseType>
    {
        public CreateShowCaseTypeValidator()
        {
            RuleFor(x => x.Type).NotEmpty();
        }
    }
    public class UpdateShowCaseTypeValidator : AbstractValidator<ShowCaseType>
    {
        public UpdateShowCaseTypeValidator()
        {
            RuleFor(x => x.Type).NotEmpty();
        }
    }
}