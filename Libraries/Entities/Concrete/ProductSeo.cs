using Core.SeedWork;
using System;

namespace Entities.Concrete
{
    public class ProductSeo : BaseEntity, IEntity
    {
        public string SeoTitle { get; set; }
        public string SeoContent { get; set; }
        public string SeoKey { get; set; }
        public Guid ProductId { get; set; }
    }
}
