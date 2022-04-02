using Entities.Concrete.CommentsAggregate;
using Entities.DTO.Product;
using Entities.DTO.ProductAttributeCombinations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels.WebViewModel.Home
{
    public class ProductDetailVM
    {
        public ProductDetailDTO ProductInfo { get; set; }
        public int ProductId { get; set; }
        public Comment CommentModel { get; set; }
        public IList<ProductAttributeCombinationDTO> AttrCombinationList { get; set; }
        public ProductAttributeCombinationDTO SelectedCombination { get; set; }
        public List<int> EnabledList { get; set; }
        public int CombinationId { get; set; }


      

    }
}
