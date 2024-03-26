using System;
using System.Collections;
using System.Collections.Generic;
namespace X.PagedList
{
    public abstract class BasePagedList<T> : PagedListMetaData, IPagedList<T>
    {
        protected readonly List<T> Subset = new();
        protected internal BasePagedList()
        {
        }
        protected internal BasePagedList(int pageNumber, int pageSize, int totalItemCount)
        {
            if (pageNumber < 1)
            {
                throw new ArgumentOutOfRangeException($"pageNumber = {pageNumber}. PageNumber cannot be below 1.");
            }
            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException($"pageSize = {pageSize}. PageSize cannot be less than 1.");
            }
            if (totalItemCount < 0)
            {
                throw new ArgumentOutOfRangeException($"totalItemCount = {totalItemCount}. TotalItemCount cannot be less than 0.");
            }
            // set source to blank list if superset is null to prevent exceptions
            TotalItemCount = totalItemCount;
            PageSize = pageSize;
            PageNumber = pageNumber;
            PageCount = TotalItemCount > 0
                            ? (int)Math.Ceiling(TotalItemCount / (double)PageSize)
                            : 0;
            bool pageNumberIsGood = PageCount > 0 && PageNumber <= PageCount;
            HasPreviousPage = pageNumberIsGood && PageNumber > 1;
            HasNextPage = pageNumberIsGood && PageNumber < PageCount;
            IsFirstPage = pageNumberIsGood && PageNumber == 1;
            IsLastPage = pageNumberIsGood && PageNumber == PageCount;
            var numberOfFirstItemOnPage = ((PageNumber - 1) * PageSize) + 1;
            FirstItemOnPage = pageNumberIsGood ? numberOfFirstItemOnPage : 0;
            var numberOfLastItemOnPage = numberOfFirstItemOnPage + PageSize - 1;
            LastItemOnPage = pageNumberIsGood
                                ? (numberOfLastItemOnPage > TotalItemCount
                                   ? TotalItemCount
                                   : numberOfLastItemOnPage)
                                : 0;
        }
        #region IPagedList<T> Members
        public IEnumerator<T> GetEnumerator()
        {
            return Subset.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public T this[int index] => Subset[index];
        public virtual int Count => Subset.Count;
        public PagedListMetaData GetMetaData()
        {
            return new PagedListMetaData(this);
        }
        #endregion
    }
}