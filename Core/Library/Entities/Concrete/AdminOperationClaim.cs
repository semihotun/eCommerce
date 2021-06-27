using eCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Library.Entities.Concrete
{
    public class AdminOperationClaim : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
