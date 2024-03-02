using Core.Utilities.DataTable;
using Entities.DTO.Brand;
namespace DataAccess.DALs.EntitiyFramework.BrandAggregate.Brands.BrandDALModels
{
    public class GetBrandDataTable
    {
        public GetBrandDataTable(BrandDataTableFilter brand, DTParameters dataTableParam)
        {
            Brand = brand;
            DataTableParam = dataTableParam;
        }
        public GetBrandDataTable()
        {
        }
        public BrandDataTableFilter Brand { get; set; }
        public DTParameters DataTableParam { get; set; }
    }
}
