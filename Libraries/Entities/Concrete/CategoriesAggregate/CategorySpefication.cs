using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete.CategoriesAggregate
{
    public class CategorySpefication : BaseEntity
    {
        public int? CategoryId { get; set; }

        public int? SpeficationAttributeId { get; set; }

    }
}
