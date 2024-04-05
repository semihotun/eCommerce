namespace Entities.Dtos.CategoryDALModels
{
    public class GetCategorySpeficationOptionDTO
    {
        public GetCategorySpeficationOptionDTO(int categoryId)
        {
            CategoryId = categoryId;
        }
        public GetCategorySpeficationOptionDTO()
        {
        }
        public int CategoryId { get; set; }
    }
}
