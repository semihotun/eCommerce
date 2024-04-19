using Business.Services.BrandAggregate.Brands.Queries;
using Business.Services.BrandAggregate.CatalogBrands.Commands;
using Business.Services.BrandAggregate.CatalogBrands.DtoQueries;
using DataAccess.Repository.Read;
using DataAccess.Repository.Write;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Business.Jobs.Quartz.CatalogAggregate
{
    /// <summary>
    /// Geçici
    /// </summary>
    public class AddCatalogBrandJob : IJob
    {
        private readonly IBrandQueryService _brandQueryService;
        private readonly IReadDbRepository<Product> _productRepository;
        private readonly IWriteDbRepository<CatalogBrand> _catalogBrandWriteRepository;
        private readonly IUnitOfWork _unitOfWork;
        public async Task Execute(IJobExecutionContext context)
        {
            var productsGroup = _productRepository.Query().GroupBy(x => new { x.BrandId, x.CategoryId }).Select(gcs => new
            {
                gcs.Key.BrandId,
                gcs.Key.CategoryId
            });
            var catalogList = new List<CatalogBrand>();
            foreach (var item in productsGroup)
            {
                var brand =(await _brandQueryService.GetBrand(new((Guid)item.BrandId))).Data;
                var isAddedBrand = await _catalogBrandWriteRepository.GetAsync(x => x.CategoryId == item.CategoryId && x.BrandId == brand.Id);
                if (isAddedBrand != null && !catalogList.Any(x => x.CategoryId == item.CategoryId && x.BrandId == brand.Id))
                {
                    catalogList.Add(new CatalogBrand
                    {
                        BrandName = brand.BrandName,
                        CategoryId = (Guid)item.CategoryId,
                        BrandId = brand.Id
                    });
                }
            }
            //await _unitOfWork.BeginTransaction(async () => await _catalogBrandWriteRepository.AddRangeAsync(catalogList));
        }
    }
}
