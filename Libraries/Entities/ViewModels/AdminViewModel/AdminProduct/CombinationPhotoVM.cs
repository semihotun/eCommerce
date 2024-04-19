using Entities.Concrete;
using System;
namespace Entities.ViewModels.AdminViewModel.AdminProduct
{
    public class CombinationPhotoVM
    {
        public Guid ProductId { get; set; }
        public Guid Id { get; set; }
        public string Combinations { get; set; }
        public string NotCombinations { get; set; }
        public Guid CombinationId { get; set; }
        public Guid PhotoId { get; set; }
        public ProductPhoto ProductPhoto { get; set; }
        public ProductAttributeCombination ProductAttributeCombination { get; set; }
    }
}
