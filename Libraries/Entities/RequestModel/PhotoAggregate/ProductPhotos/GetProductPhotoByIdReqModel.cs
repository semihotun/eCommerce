namespace Entities.RequestModel.PhotoAggregate.ProductPhotos
{
    public class GetProductPhotoByIdReqModel
    {
        public GetProductPhotoByIdReqModel()
        {
            
        }
        public GetProductPhotoByIdReqModel(int photoId)
        {
            PhotoId = photoId;
        }
        public int PhotoId { get; set; }
    }
}
