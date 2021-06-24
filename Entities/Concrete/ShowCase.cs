namespace Entities.Concrete
{
    using System;
    using System.Collections.Generic;
    
    public  class ShowCase : BaseEntity
    {
        public int ShowCaseOrder { get; set; }

        public string ShowCaseTitle { get; set; }

        public int ShowCaseType { get; set; }

        public string ShowCaseText   { get; set; }      
    }
}
