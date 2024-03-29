﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace X.PagedList
{
    public class PagedList<T, TKey> : BasePagedList<T>
    {
        public PagedList(IQueryable<T> superset, Expression<Func<T, TKey>> keySelector, int pageNumber, int pageSize)
            : base(pageNumber, pageSize, superset?.Count() ?? 0)
        {
            // add items to internal list
            if (TotalItemCount > 0)
            {
                InitSubset(superset, keySelector.Compile(), pageNumber, pageSize);
            }
        }
        public PagedList(IQueryable<T> superset, Func<T, TKey> keySelectorMethod, int pageNumber, int pageSize)
            : base(pageNumber, pageSize, superset?.Count() ?? 0)
        {
            if (TotalItemCount > 0)
            {
                InitSubset(superset, keySelectorMethod, pageNumber, pageSize);
            }
        }
        private void InitSubset(IEnumerable<T> superset, Func<T, TKey> keySelectorMethod, int pageNumber, int pageSize)
        {
            // add items to internal list
            var items = pageNumber == 1
                ? superset.OrderBy(keySelectorMethod).Take(pageSize).ToList()
                : superset.OrderBy(keySelectorMethod).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            Subset.AddRange(items);
        }
    }
    public class PagedList<T> : BasePagedList<T>
    {
        public PagedList(IQueryable<T> superset, int pageNumber, int pageSize)
            : base(pageNumber, pageSize, superset?.Count() ?? 0)
        {
            if (TotalItemCount > 0)
            {
                Subset.AddRange(pageNumber == 1
                    ? superset.Take(pageSize).ToList()
                    : superset.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList()
                );
            }
        }
        public PagedList(IEnumerable<T> superset, int pageNumber, int pageSize)
            : this(superset.AsQueryable<T>(), pageNumber, pageSize)
        {
        }
        public PagedList(IPagedList pagedList, IEnumerable<T> superset)
        {
            TotalItemCount = pagedList.TotalItemCount;
            PageSize = pagedList.PageSize;
            PageNumber = pagedList.PageNumber;
            PageCount = pagedList.PageCount;
            HasPreviousPage = pagedList.HasPreviousPage;
            HasNextPage = pagedList.HasNextPage;
            IsFirstPage = pagedList.IsFirstPage;
            IsLastPage = pagedList.IsLastPage;
            FirstItemOnPage = pagedList.FirstItemOnPage;
            LastItemOnPage = pagedList.LastItemOnPage;
            Subset.AddRange(superset);
        }
    }
}
