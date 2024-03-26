using DataAccess.DALs.EntitiyFramework.BrandAggregate.Brands;
using DataAccess.DALs.EntitiyFramework.BrandAggregate.CatalogBrands;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products;
using Entities.Concrete.BrandAggregate;
using Quartz;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Business.Jobs.Quartz.CatalogAggregate
{
    public class AddCatalogBrandJob : IJob
    {
        private readonly ICatalogBrandDAL _catalogBrandDal;
        private readonly IBrandDAL _brandDal;
        private readonly IProductDAL _productDAL;
        public AddCatalogBrandJob(ICatalogBrandDAL catalogBrandDal, IBrandDAL brandDal, IProductDAL productDAL)
        {
            _productDAL = productDAL;
            _brandDal = brandDal;
            _catalogBrandDal = catalogBrandDal;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            var productsGroup = _productDAL.Query().GroupBy(x => new { x.BrandId, x.CategoryId }).Select(gcs => new
            {
                gcs.Key.BrandId,
                gcs.Key.CategoryId
            });
            var catalogList = new List<CatalogBrand>();
            foreach (var item in productsGroup)
            {
                var brand = _brandDal.Query().Where(x => x.Id == item.BrandId).FirstOrDefault();
                var isAddedBrand = _catalogBrandDal.Query().Where(x => x.CategoryId == item.CategoryId)
                    .Any(x => x.BrandId == brand.Id);
                if (!isAddedBrand && !catalogList.Any(x => x.CategoryId == item.CategoryId && x.BrandId == brand.Id))
                {
                    catalogList.Add(new CatalogBrand
                    {
                        BrandName = brand.BrandName,
                        CategoryId = (int)item.CategoryId,
                        BrandId = brand.Id
                    });
                }
            }
            await _catalogBrandDal.AddRangeAsync(catalogList);
            await Task.CompletedTask;
        }
    }
}
