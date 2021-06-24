
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels.Admin
{
    public class OrderNoteModel :BaseEntity
    {
        public string Note { get; set; }

        public int OrderId { get; set; }

        public int DownloadId { get; set; }

        public bool DisplayToCustomer { get; set; }
        public DateTime CreatedOnUtc { get; set; }

        public virtual OrderModel Order { get; set; }
    }
}
