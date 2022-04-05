using Entities.Concrete.AdressAggregate;
using FluentValidation;

namespace Business.Validator
{

    public class CreateMyUserAdressesValidator : AbstractValidator<MyUserAdresses>
    {
        public CreateMyUserAdressesValidator()
        {
            RuleFor(x => x.AddressId).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();

        }
    }
    public class UpdateMyUserAdressesValidator : AbstractValidator<MyUserAdresses>
    {
        public UpdateMyUserAdressesValidator()
        {
            RuleFor(x => x.AddressId).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();

        }
    }
}