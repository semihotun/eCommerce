namespace Entities.Concrete.CategoriesAggregate
{
    using System;
    using System.Collections.Generic;


    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }

    }
}
