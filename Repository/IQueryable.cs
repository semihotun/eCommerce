
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eCommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using DataAccess.Concrete.EntityFramework;

namespace eCommerce.Repository
{
    public class Queryable<T> : IQueryable<T> where T : class, IEntitiy, new()
    {
        private readonly eCommerceContext _context;
        private DbSet<T> _entities;

        public Queryable(eCommerceContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public virtual IQueryable<T> Table => (IQueryable<T>)Entities.AsQueryable();

        protected virtual DbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());
    }

    public interface IQueryable<T> where T : class, IEntitiy, new()
    {
        IQueryable<T> Table { get; }
    }
}
