using System.Linq;
namespace Entities.Others
{
    public class DataTablesParam
    {
        public int iDisplayStart { get; set; }
        public int iDisplayLength { get; set; }
        public int iColumns { get; set; }
        public string sSearch { get; set; }
        public int iSortingCols { get; set; }
        public int sEcho { get; set; }
        public int iSortCol_0 { get; set; }
        public string sSortDir_0 { get; set; }
        public string sColumns { get; set; }
        public int PageIndex
        {
            get
            {
                int pageNo = 1;
                if (iDisplayStart >= iDisplayLength && iDisplayStart != 0 || iDisplayLength != 0)
                {
                    pageNo = (iDisplayStart / iDisplayLength) + 1;
                }
                return pageNo;
            }
            set { PageIndex = value; }
        }
        public string[] ColumnListArray
        {
            get
            {
                var data = sColumns.ToString().Split(',').ToArray();
                return data;
            }
            set
            {
                ColumnListArray = value;
            }
        }
        public string SortedColumnName
        {
            get
            {
                var data = ColumnListArray[iSortCol_0];
                return data;
            }
            set
            {
                SortedColumnName = value;
            }
        }
        public int PageSize
        {
            get
            {
                if (iDisplayLength == 0)
                    return int.MaxValue;
                else
                    return iDisplayLength;
            }
            set { PageSize = value; }
        }
        public string ColumnOrder
        {
            get
            {
                var data = SortedColumnName + " " + sSortDir_0;
                return data;
            }
            set
            {
                ColumnOrder = value;
            }
        }
    }
}
