using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;

namespace Core.Utilities.Results
{
    public class DataTableNewVersionResult<T>
    {
        public IPagedList<T> data { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }

        public int draw { get; set; }
    }

}
