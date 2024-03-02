namespace Entities.Concrete.PhotoAggregate
{
    using System;
    using System.Collections.Generic;
    public class ProductPhoto : BaseEntity
    {
        public string ProductPhotoName { get; set; }
        public int? ProductId { get; set; }
    }
}
