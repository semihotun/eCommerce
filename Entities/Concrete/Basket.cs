using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Basket:BaseEntity
    {
        public int ProductId { get; set; }
        public int CombinationId { get; set; }
        public int UserId { get; set; }
        public int ProductPiece { get; set; }
    }
}
