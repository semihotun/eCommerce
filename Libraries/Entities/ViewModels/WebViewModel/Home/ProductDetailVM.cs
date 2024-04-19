using Entities.Concrete;
using Entities.Dtos.ProductAttributeCombinationDALModels;
using Entities.Dtos.ProductDALModels;
using System;
using System.Collections.Generic;
namespace Entities.ViewModels.WebViewModel.Home
{
    public class ProductDetailVM
    {
        public ProductDetailDTO ProductInfo { get; set; }
        public Guid ProductId { get; set; }
        public Comment CommentModel { get; set; }
        public IList<ProductAttributeCombinationDTO> AttrCombinationList { get; set; }
        public ProductAttributeCombinationDTO SelectedCombination { get; set; }
        public List<Guid> EnabledList { get; set; }
        public Guid CombinationId { get; set; }
    }
}
