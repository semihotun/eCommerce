using Entities.Concrete.AdressAggregate;
using FluentValidation;
namespace Business.Validator
{
    public class CreateAddressValidator : AbstractValidator<Address>
    {
        public CreateAddressValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Company).NotEmpty();
            RuleFor(x => x.County).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Address1).NotEmpty();
            RuleFor(x => x.Address2).NotEmpty();
            RuleFor(x => x.ZipPostalCode).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.FaxNumber).NotEmpty();
            RuleFor(x => x.CustomAttributes).NotEmpty();
            RuleFor(x => x.CreatedOnUtc).NotEmpty();
        }
    }
    public class UpdateAddressValidator : AbstractValidator<Address>
    {
        public UpdateAddressValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Company).NotEmpty();
            RuleFor(x => x.County).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Address1).NotEmpty();
            RuleFor(x => x.Address2).NotEmpty();
            RuleFor(x => x.ZipPostalCode).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.FaxNumber).NotEmpty();
            RuleFor(x => x.CustomAttributes).NotEmpty();
            RuleFor(x => x.CreatedOnUtc).NotEmpty();
        }
    }
}