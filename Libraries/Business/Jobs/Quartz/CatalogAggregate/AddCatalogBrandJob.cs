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
            var productsGroup = (from p in _productDAL.Query().AsEnumerable()
                                 group p by p.CategoryId into pg
                                 select pg);

            var catalogList = new List<CatalogBrand>();
            foreach (var category in productsGroup)
            {
                foreach (var item in category.Distinct())
                {
                    var brand = _brandDal.Query().Where(x => x.Id == item.BrandId).FirstOrDefault();

                    var isAddedBrand = _catalogBrandDal.Query().Where(x => x.CategoryId == category.Key.Value)
                        .Any(x => x.BrandName == brand.BrandName);

                    if (!isAddedBrand && catalogList.Any(x=>x.CategoryId == item.CategoryId && x.BrandName == brand.BrandName) == false)
                        catalogList.Add(new CatalogBrand
                        {
                            BrandName = brand.BrandName,
                            CategoryId = (int)item.CategoryId,
                            BrandId = brand.Id
                        });
                }
            }
            _catalogBrandDal.AddRange(catalogList);
            _catalogBrandDal.SaveChanges();

        }
    }
}
