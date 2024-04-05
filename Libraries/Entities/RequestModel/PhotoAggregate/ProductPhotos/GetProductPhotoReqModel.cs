using Core.Utilities.DataTable;

namespace Entities.RequestModel.PhotoAggregate.ProductPhotos
{
    public class GetProductPhotoReqModel
    {
        public GetProductPhotoReqModel()
        {

        }
        public int Id { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string OrderByText { get; set; }
        public DTParameters Param { get; set; }
        public GetProductPhotoReqModel(int id, DTParameters param)
        {
            Param = param;
            Id = id;
        }
    }
}
