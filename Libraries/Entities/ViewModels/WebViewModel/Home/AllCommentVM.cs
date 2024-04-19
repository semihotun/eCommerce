using Entities.Concrete;
using Entities.Dtos.ProductDALModels;
namespace Entities.ViewModels.WebViewModel.Home
{
    public class AllCommentVM
    {
        public ProductCommentDTO ProductCommentDTO { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public CustomerUser Users { get; set; }
        public Product Product { get; set; }
    }
}
