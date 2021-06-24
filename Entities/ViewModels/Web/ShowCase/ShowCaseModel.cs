
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using X.PagedList;

namespace Entities.ViewModels.Web
{


    public class ShowCaseModel
    {

        public ShowCaseModel()
        {
            selectedProducts = new List<ShowCaseProductModel>();
        }
        public int Id { get; set; }

        public int ShowCaseOrder { get; set; }

        public string ShowCaseTitle { get; set; }

        public int SearchProductId { get; set; }

        public string SearchProductName { get; set; }

        public int? ShowCaseType { get; set; }

        [UIHint("tinymce_full")]
        public string ShowCaseText { get; set; }

        public string Tap { get; set; }
        public IPagedList<ProductModel> AllProducts { get; set; }

        public ProductModel ProductModel { get; set; }
        public IList<ShowCaseProductModel> selectedProducts { get; set; }

        public int page { get; set; }
        public int pagesize { get; set; }

    }
}
