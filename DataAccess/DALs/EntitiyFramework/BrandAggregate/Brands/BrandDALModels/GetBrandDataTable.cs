using Core.Utilities.DataTable;
using Entities.DTO.Brand;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DALs.EntitiyFramework.BrandAggregate.Brands.BrandDALModels
{
    public class GetBrandDataTable
    {
        public GetBrandDataTable(BrandDataTableFilter brand, DTParameters dataTableParam)
        {
            Brand = brand;
            DataTableParam = dataTableParam;
        }

        public BrandDataTableFilter Brand { get; set; }
        public DTParameters DataTableParam { get; set; }
       
    }
}
