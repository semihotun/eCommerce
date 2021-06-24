namespace Entities.Concrete
{
    using System;
    using System.Collections.Generic;
    

    public  class ShowCaseProduct : BaseEntity
    {
        public int ShowCaseId { get; set; }

        public int ProductId { get; set; }

        public int CombinationId { get; set; }
    }
}
