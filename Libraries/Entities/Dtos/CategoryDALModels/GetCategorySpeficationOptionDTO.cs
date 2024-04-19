using System;

namespace Entities.Dtos.CategoryDALModels
{
    public class GetCategorySpeficationOptionDTO
    {
        public GetCategorySpeficationOptionDTO(Guid categoryId)
        {
            CategoryId = categoryId;
        }
        public GetCategorySpeficationOptionDTO()
        {
        }
        public Guid CategoryId { get; set; }
    }
}
