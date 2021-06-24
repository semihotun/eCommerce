
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class OrderNote :BaseEntity
    {
        public string Note { get; set; }

        public int OrderId { get; set; }

        public int DownloadId { get; set; }

        public bool DisplayToCustomer { get; set; }
        public DateTime CreatedOnUtc { get; set; }

    }
}
