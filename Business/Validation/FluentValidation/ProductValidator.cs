using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validation.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(c => c.ProductName).NotEmpty().WithMessage("Ürün İsmini doldurun");
            RuleFor(c => c.BrandId).NotEmpty().WithMessage("Lütfen Marka Seçiniz");
            RuleFor(c => c.CategoryId).NotEmpty().WithMessage("Lütfen Kategori Seçiniz");
        }
    }
}
