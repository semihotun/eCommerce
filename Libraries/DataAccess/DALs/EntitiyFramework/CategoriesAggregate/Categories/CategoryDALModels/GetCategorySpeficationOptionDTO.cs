namespace DataAccess.DALs.EntitiyFramework.CategoriesAggregate.Categories.CategoryDALModels
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
