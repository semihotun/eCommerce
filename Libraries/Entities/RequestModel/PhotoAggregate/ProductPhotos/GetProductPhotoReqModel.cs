using Core.Utilities.DataTable;
using System;

namespace Entities.RequestModel.PhotoAggregate.ProductPhotos
{
    public class GetProductPhotoReqModel
    {
        public GetProductPhotoReqModel()
        {

        }
        public Guid Id { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string OrderByText { get; set; }
        public DTParameters Param { get; set; }
        public GetProductPhotoReqModel(Guid id, DTParameters param)
        {
            Param = param;
            Id = id;
        }
    }
}
