using Entities.Concrete.OrderAggregate;
using FluentValidation;
namespace Business.Validator
{
    public class CreateOrderNoteValidator : AbstractValidator<OrderNote>
    {
        public CreateOrderNoteValidator()
        {
            RuleFor(x => x.Note).NotEmpty();
            RuleFor(x => x.OrderId).NotEmpty();
            RuleFor(x => x.DownloadId).NotEmpty();
            RuleFor(x => x.DisplayToCustomer).NotEmpty();
            RuleFor(x => x.CreatedOnUtc).NotEmpty();
        }
    }
    public class UpdateOrderNoteValidator : AbstractValidator<OrderNote>
    {
        public UpdateOrderNoteValidator()
        {
            RuleFor(x => x.Note).NotEmpty();
            RuleFor(x => x.OrderId).NotEmpty();
            RuleFor(x => x.DownloadId).NotEmpty();
            RuleFor(x => x.DisplayToCustomer).NotEmpty();
            RuleFor(x => x.CreatedOnUtc).NotEmpty();
        }
    }
}