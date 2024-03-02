namespace Entities.Concrete.ProductAggregate
{
    public class ProductSeo : BaseEntity
    {
        public string SeoTitle { get; set; }
        public string SeoContent { get; set; }
        public string SeoKey { get; set; }
        public int ProductId { get; set; }
    }
}
