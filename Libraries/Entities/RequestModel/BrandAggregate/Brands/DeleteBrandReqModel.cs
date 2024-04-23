using System;

namespace Entities.RequestModel.BrandAggregate.Brands
{
    public class DeleteBrandReqModel
    {
        public Guid Id { get; set; }
        public DeleteBrandReqModel()
        {

        }
        public DeleteBrandReqModel(Guid id)
        {
            Id = id;
        }
    }
}
