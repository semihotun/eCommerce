using Entities.Concrete.SpeficationAggregate;
using FluentValidation;

namespace Business.Services.SpeficationAggregate.SpecificationAttributeOptions.Validator
{

    public class CreateSpecificationAttributeOptionValidator : AbstractValidator<SpecificationAttributeOption>
    {
        public CreateSpecificationAttributeOptionValidator()
        {
            RuleFor(x => x.SpecificationAttributeId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.ColorSquaresRgb).NotEmpty();
            RuleFor(x => x.DisplayOrder).NotEmpty();

        }
    }
    public class UpdateSpecificationAttributeOptionValidator : AbstractValidator<SpecificationAttributeOption>
    {
        public UpdateSpecificationAttributeOptionValidator()
        {
            RuleFor(x => x.SpecificationAttributeId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.ColorSquaresRgb).NotEmpty();
            RuleFor(x => x.DisplayOrder).NotEmpty();

        }
    }
}