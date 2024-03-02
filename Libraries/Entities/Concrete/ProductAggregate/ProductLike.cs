using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities.Concrete.ProductAggregate
{
    public class ProductLike : BaseEntity
    {
        public int ProductId { get; set; }
        public int CombinationId { get; set; }
        public int UserId { get; set; }
    }
}
