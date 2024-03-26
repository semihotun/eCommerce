using Business.Jobs.Quartz.CatalogAggregate;
using Core.Utilities.Quartz;
using Microsoft.Extensions.DependencyInjection;
namespace Business.Extension
{
    public static class JobStartUpExtension
    {
        public static void AddJobList(this IServiceCollection services)
        {
            services.AddQuartzSingleton<AddCatalogBrandJob>("0 0/1 * * * ? *");
        }
    }
}
