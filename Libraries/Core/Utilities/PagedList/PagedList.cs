using System.Collections.Generic;

namespace Core.Utilities.PagedList
{
    /// <summary>
    /// paged list for grid
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedList<T> : IPagedList<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage => PageIndex > 0;
        public bool HasNextPage => PageIndex + 1 < TotalPages;
        public PagedList()
        {
            Data = new List<T>();
            PageIndex = 0;
            PageSize = 0;
            TotalCount = 0;
        }
        public PagedList(List<T> data, int pageIndex, int pageSize, int totalCount, int totalPages)
        {
            Data = data;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = totalPages;
        }
    }
}
