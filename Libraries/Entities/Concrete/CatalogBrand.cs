using Core.SeedWork;
using System;
namespace Entities.Concrete
{
    public class CatalogBrand : BaseEntity, IEntity
    {
        public string BrandName { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
    }
}
