﻿using Entities.Concrete.ProductAggregate;
using System;
namespace Entities.DTO.Product
{
    public class ProductStockDto
    {
        public int Id { get; set; }
        public double? ProductPrice { get; set; }
        public double? ProductDiscount { get; set; }
        public int? ProductStockPiece { get; set; }
        public bool AllowOutOfStockOrders { get; set; }
        public int NotifyAdminForQuantityBelow { get; set; }
        public DateTime CreateTime { get; set; }
        public int ProductId { get; set; }
        public int CombinationId { get; set; }
        public String ProductName { get; set; }
        public Concrete.ProductAggregate.Product Product { get; set; }
        public ProductAttributeCombination ProductAttributeCombination { get; set; }
    }
}
