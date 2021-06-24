using Entities.DTO.ProductMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.DTO.Product;
using Entities.Concrete;

namespace Entities.ViewModels.Web
{
    public class ProductDetailModel
    {
        public ProductDetailDTO ProductInfo { get; set; }
        public int ProductId { get; set; }
        public Comment CommentModel { get; set; }
        public IList<ProductAttributeCombinationModel> AttrCombinationList { get; set; }
        public ProductAttributeCombinationModel SelectedCombination { get; set; }
        public List<int>EnabledList { get; set; }
        public int CombinationId { get; set; }

    }
}