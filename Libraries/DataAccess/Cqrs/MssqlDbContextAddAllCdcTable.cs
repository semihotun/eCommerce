using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Cqrs
{
    public static class MssqlDbContextAddAllCdcTable
    {
        public static void AddAllCdc(ECommerceContext ctx)
        {
            ctx.Database.ExecuteSqlRaw("EXEC sys.sp_cdc_enable_db;");
            foreach (var entityType in ctx.Model.GetEntityTypes())
            {
                ctx.Database.ExecuteSqlRaw($"EXEC sys.sp_cdc_enable_table @source_schema = N'dbo', @source_name = N'{entityType.GetTableName()}', @role_name = NULL;");
            }
        }
    }
}
