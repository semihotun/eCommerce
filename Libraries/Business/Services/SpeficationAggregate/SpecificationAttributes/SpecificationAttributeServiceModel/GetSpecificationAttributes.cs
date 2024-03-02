namespace Business.Services.SpeficationAggregate.SpecificationAttributes.SpecificationAttributeServiceModel
{
    public class GetSpecificationAttributes
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public GetSpecificationAttributes(int pageIndex = 1, int pageSize = int.MaxValue)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
        public GetSpecificationAttributes()
        {
        }
    }
}
