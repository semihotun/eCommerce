namespace Entities.RequestModel.PhotoAggregate.CombinationPhotos
{
    public class GetAllCombinationPhotosReqModel
    {
        public GetAllCombinationPhotosReqModel()
        {
            
        }
        public GetAllCombinationPhotosReqModel(int productId, int photoId)
        {
            ProductId = productId;
            PhotoId = photoId;
        }
        public int ProductId { get; set; }
        public int PhotoId { get; set; }
    }
}
