namespace Entities.RequestModel.PhotoAggregate.ProductPhotos
{
    public class DeleteProductPhotoReqModel
    {
        public DeleteProductPhotoReqModel()
        {
            
        }
        public DeleteProductPhotoReqModel(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
