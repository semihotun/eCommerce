using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities.ViewModels.Admin
{
    public class ProductDetailModel
    {

        public int ProductId { get; set; }
        public ProductModel ProductModel { get; set; }

        public List<ProductModel> AnotherProductlist { get; set; }

        public List<CommentModel> CommentList { get; set; }

        public CommentModel CommentModel { get; set; }

        public List<ProductAttributeCombinationModel> AttrCombinationList { get; set; }

        public IList<ProductAttributeMappingModel> ProductAttributeMappingList { get; set; }

        public List<int>DisabledList { get; set; }

        public int CommentCount { get; set; }

    }
}