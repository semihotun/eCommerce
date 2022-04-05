using Entities.Concrete.ProductAggregate;
using FluentValidation;

namespace Business.Services.ProductAggregate.ProductStocks.Validator
{

    public class CreateProductStockValidator : AbstractValidator<ProductStock>
    {
        public CreateProductStockValidator()
        {
            RuleFor(x => x.AllowOutOfStockOrders).NotEmpty();
            RuleFor(x => x.NotifyAdminForQuantityBelow).NotEmpty();
            RuleFor(x => x.CreateTime).NotEmpty();
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.CombinationId).NotEmpty();

        }
    }
    public class UpdateProductStockValidator : AbstractValidator<ProductStock>
    {
        public UpdateProductStockValidator()
        {
            RuleFor(x => x.AllowOutOfStockOrders).NotEmpty();
            RuleFor(x => x.NotifyAdminForQuantityBelow).NotEmpty();
            RuleFor(x => x.CreateTime).NotEmpty();
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.CombinationId).NotEmpty();

        }
    }
}