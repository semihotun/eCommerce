using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.ShowcaseAggregate.ShowCaseProducts.ShowCaseProductServiceModel
{
    public class DeleteShowCaseProduct
    {
        public DeleteShowCaseProduct(int ıd)
        {
            Id = ıd;
        }

        public DeleteShowCaseProduct()
        {
        }

        public int Id { get; set; }
    }
}
