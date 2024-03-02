using System;
using System.Collections.Generic;
using System.Text;
namespace Business.Services.ProductAggregate.ProductAttributeCombinations.ProductAttributeCombinationServiceModel
{
    public class InsertPermutationCombination
    {
        public InsertPermutationCombination(List<List<int>> data, int productId)
        {
            Data = data;
            ProductId = productId;
        }
        public InsertPermutationCombination()
        {
        }
        public List<List<int>> Data { get; set; }
        public int ProductId { get; set; }
    }
}
