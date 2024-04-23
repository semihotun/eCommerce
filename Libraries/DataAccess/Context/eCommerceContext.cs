using Core.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
namespace DataAccess.Context
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public IQueryable<TEntity> Query<TEntity>() where TEntity : BaseEntity
        {
            return Set<TEntity>().AsQueryable().Where(x => !x.IsDeleted);
        }
    }
}
