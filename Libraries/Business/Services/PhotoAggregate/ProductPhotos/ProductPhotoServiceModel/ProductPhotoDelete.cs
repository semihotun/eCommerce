namespace Business.Services.PhotoAggregate.ProductPhotos.ProductPhotoServiceModel
{
    public class DeleteProductPhoto
    {
        public DeleteProductPhoto(int id)
        {
            Id = id;
        }
        public DeleteProductPhoto()
        {
        }
        public int Id { get; set; }
    }
}
