using Core.SeedWork;
using System;
namespace Entities.Concrete
{
    public class CategorySpefication : BaseEntity, IEntity
    {
        public Guid? CategoryId { get; set; }
        public Guid? SpeficationAttributeId { get; set; }
    }
}
