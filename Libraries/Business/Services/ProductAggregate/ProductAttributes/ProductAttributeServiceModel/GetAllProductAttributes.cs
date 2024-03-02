namespace Business.Services.ProductAggregate.ProductAttributes.ProductAttributeServiceModel
{
    public class GetAllProductAttributes
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }
        public GetAllProductAttributes(int pageIndex = 0, int pageSize = int.MaxValue, string name = null)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Name = name;
        }
        public GetAllProductAttributes()
        {
        }
    }
}
