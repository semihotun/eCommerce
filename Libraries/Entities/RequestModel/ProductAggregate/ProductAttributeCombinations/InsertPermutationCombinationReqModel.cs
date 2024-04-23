using System;
using System.Collections.Generic;
namespace Entities.RequestModel.ProductAggregate.ProductAttributeCombinations
{
    public class InsertPermutationCombinationReqModel
    {
        public InsertPermutationCombinationReqModel()
        {

        }
        public InsertPermutationCombinationReqModel(List<List<Guid>> data, Guid productId)
        {
            Data = data;
            ProductId = productId;
        }
        public List<List<Guid>> Data { get; set; }
        public Guid ProductId { get; set; }
    }
}
