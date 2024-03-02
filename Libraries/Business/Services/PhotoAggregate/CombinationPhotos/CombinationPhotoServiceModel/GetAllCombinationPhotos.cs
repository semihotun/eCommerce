namespace Business.Services.PhotoAggregate.CombinationPhotos.CombinationPhotoServiceModel
{
    public class GetAllCombinationPhotos
    {
        public GetAllCombinationPhotos(int productId, int photoId)
        {
            ProductId = productId;
            PhotoId = photoId;
        }
        public GetAllCombinationPhotos()
        {
        }
        public int ProductId { get; set; }
        public int PhotoId { get; set; }
    }
}
