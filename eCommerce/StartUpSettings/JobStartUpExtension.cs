using Business.Jobs.Quartz.CatalogAggregate;
using Core.Utilities.Quartz;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.StartUpSettings
{
    public static class JobStartUpExtension
    {
        public static void AddJobList(this IServiceCollection services){

            //55'dkda  bir Ürünlere göre catalog brand'e aktar
            services.AddQuartzSingleton<AddCatalogBrandJob>("0 0/1 * * * ? *");

        }
    }
}
