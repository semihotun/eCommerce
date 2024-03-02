using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities.Concrete.PhotoAggregate
{
    public class CombinationPhoto : BaseEntity
    {
        public int CombinationId { get; set; }
        public int PhotoId { get; set; }
    }
}
