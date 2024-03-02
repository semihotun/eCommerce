using System;
using System.Collections.Generic;
using System.Text;
namespace Entities.Concrete.BasketAggregate
{
    public class Basket : BaseEntity
    {
        public int ProductId { get; set; }
        public int CombinationId { get; set; }
        public int UserId { get; set; }
        public int ProductPiece { get; set; }
    }
}
