using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.ProductAggregate.ProductAttributeCombinations.ProductAttributeCombinationServiceModel
{
    public class DeleteProductAttributeCombination
    {
        public DeleteProductAttributeCombination(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
