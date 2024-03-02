using Entities.Concrete.PhotoAggregate;
using Entities.Concrete.ProductAggregate;
namespace Entities.ViewModels.AdminViewModel.AdminProduct
{
    public class CombinationPhotoVM
    {
        public int ProductId { get; set; }
        public int Id { get; set; }
        public string Combinations { get; set; }
        public string NotCombinations { get; set; }
        public int CombinationId { get; set; }
        public int PhotoId { get; set; }
        public ProductPhoto ProductPhoto { get; set; }
        public ProductAttributeCombination ProductAttributeCombination { get; set; }
    }
}
