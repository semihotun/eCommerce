using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;
namespace Core.Utilities.Results
{
    public class DataTableResult<T>
    {
        public IPagedList<T> aaData { get; set; }
        public int sEcho { get; set; }
        public int iTotalDisplayRecords { get; set; }
        public int iTotalRecords { get; set; }
    }
}
