using Entities.Concrete.ShowcaseAggregate;
using FluentValidation;
namespace Business.Services.ShowcaseAggregate.ShowcaseServices.Validator
{
    public class CreateShowCaseValidator : AbstractValidator<ShowCase>
    {
        public CreateShowCaseValidator()
        {
            RuleFor(x => x.ShowCaseOrder).NotEmpty();
            RuleFor(x => x.ShowCaseTitle).NotEmpty();
            RuleFor(x => x.ShowCaseType).NotEmpty();
            RuleFor(x => x.ShowCaseText).NotEmpty();
        }
    }
    public class UpdateShowCaseValidator : AbstractValidator<ShowCase>
    {
        public UpdateShowCaseValidator()
        {
            RuleFor(x => x.ShowCaseOrder).NotEmpty();
            RuleFor(x => x.ShowCaseTitle).NotEmpty();
            RuleFor(x => x.ShowCaseType).NotEmpty();
            RuleFor(x => x.ShowCaseText).NotEmpty();
        }
    }
}