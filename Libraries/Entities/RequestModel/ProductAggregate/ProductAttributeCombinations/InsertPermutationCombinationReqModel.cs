using System.Collections.Generic;
namespace Entities.RequestModel.ProductAggregate.ProductAttributeCombinations
{
    public class InsertPermutationCombinationReqModel
    {
        public InsertPermutationCombinationReqModel()
        {
            
        }
        public InsertPermutationCombinationReqModel(List<List<int>> data, int productId)
        {
            Data = data;
            ProductId = productId;
        }
        public List<List<int>> Data { get; set; }
        public int ProductId { get; set; }
    }
}
