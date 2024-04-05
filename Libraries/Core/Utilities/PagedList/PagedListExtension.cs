using Core.Utilities.PagedList;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Core.Utilities.PagedList
{
    public static class PagedListExtension
    {
        /// <summary>
        /// return to grid property veriable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<IPagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source,
            int pageIndex,
            int pageSize)
        {
            if (source == null)
                return new PagedList<T>();
            var result = new PagedList<T>
            {
                PageIndex = pageIndex,
                PageSize = Math.Max(pageSize, 1),
                TotalCount = source.Count()
            };
            result.TotalPages = result.TotalCount / result.PageSize;
            result.Data = result.PageSize < result.TotalCount
                ? await source.Skip((result.PageIndex - 1) * result.PageSize)
                    .Take(pageSize)
                    .ToListAsync()
                : await source.ToListAsync();
            if (result.TotalCount % pageSize > 0)
                result.TotalPages++;
            var sourceType = source.ElementType;
            return result;
        }
        public static IPagedList<T> ToPagedList<T>(this IQueryable<T> source,
            int pageIndex,
            int pageSize)
        {
            if (source == null)
                return new PagedList<T>();
            var result = new PagedList<T>
            {
                PageIndex = pageIndex,
                PageSize = Math.Max(pageSize, 1),
                TotalCount = source.Count()
            };
            result.TotalPages = result.TotalCount / result.PageSize;
            result.Data = result.PageSize < result.TotalCount
                ? source.Skip((result.PageIndex - 1) * result.PageSize)
                    .Take(pageSize)
                    .ToList()
                : source.ToList();
            if (result.TotalCount % pageSize > 0)
                result.TotalPages++;
            return result;
        }
        /// <summary>
        /// ToPagedList For List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static IPagedList<T> ToPagedList<T>(this List<T> source,
           int pageIndex,
           int pageSize)
        {
            if (source == null)
                return new PagedList<T>();
            var result = new PagedList<T>
            {
                PageIndex = pageIndex,
                PageSize = Math.Max(pageSize, 1),
                TotalCount = source.Count()
            };
            result.TotalPages = result.TotalCount / result.PageSize;
            result.Data = result.PageSize < result.TotalCount
                ? source.Skip((result.PageIndex - 1) * result.PageSize)
                    .Take(pageSize)
                : source;
            if (result.TotalCount % pageSize > 0)
                result.TotalPages++;
            return result;
        }
        /// <summary>
        /// ToPagedList for enumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> source,
        int pageIndex,
        int pageSize)
        {
            if (source == null)
                return new PagedList<T>();
            var result = new PagedList<T>
            {
                PageIndex = pageIndex,
                PageSize = Math.Max(pageSize, 1),
                TotalCount = source.Count()
            };
            result.TotalPages = result.TotalCount / result.PageSize;
            result.Data = result.PageSize < result.TotalCount
                ? source.Skip((result.PageIndex - 1) * result.PageSize)
                    .Take(pageSize)
                : source;
            if (result.TotalCount % pageSize > 0)
                result.TotalPages++;
            return result;
        }
        /// <summary>
        /// if we want to select the pagedlist value
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IPagedList<TResult> Select<TSource, TResult>(this IPagedList<TSource> source,
            Func<TSource, TResult> selector)
        {
            var subset = source.Data.Select(selector);
            return new PagedList<TResult>(
                data: subset.ToList(),
                pageIndex: source.PageIndex,
                pageSize: source.PageSize,
                totalCount: source.TotalCount,
                totalPages: source.TotalPages
                );
        }
    }
}
