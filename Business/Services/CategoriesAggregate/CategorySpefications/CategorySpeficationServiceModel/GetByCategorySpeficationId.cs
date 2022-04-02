using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.CategoriesAggregate.CategorySpefications.CategorySpeficationServiceModel
{
    public class GetByCategorySpeficationId
    {
        public int SpeficationId { get; set; }
        public int CategoryId { get; set; }

        public GetByCategorySpeficationId(int speficationId, int categoryId)
        {
            SpeficationId = speficationId;
            CategoryId = categoryId;
        }
    }
}
