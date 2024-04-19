using Core.SeedWork;
using System;
namespace Entities.Concrete
{
    public class Category : BaseEntity, IEntity
    {
        public string CategoryName { get; set; }
        public Guid? ParentCategoryId { get; set; }
    }
}
