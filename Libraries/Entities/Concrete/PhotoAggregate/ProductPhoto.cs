namespace Entities.Concrete.PhotoAggregate
{
    public class ProductPhoto : BaseEntity
    {
        public string ProductPhotoName { get; set; }
        public int? ProductId { get; set; }
    }
}
