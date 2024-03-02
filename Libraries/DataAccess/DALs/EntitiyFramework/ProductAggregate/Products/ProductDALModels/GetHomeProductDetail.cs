﻿using System;
using System.Collections.Generic;
using System.Text;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.Products.ProductDALModels
{
    public class GetHomeProductDetail
    {
        public int ProductId { get; set; }
        public int CombinationId { get; set; }
        public GetHomeProductDetail(int productId, int combinationId = 0 )
        {
            ProductId = productId;
            CombinationId = combinationId;
        }
        public GetHomeProductDetail()
        {
        }
    }
}
