using System.Collections.Generic;
namespace Entities.ViewModels.WebViewModel.Home
{
    public class SearchVM
    {
        public List<ProductSearch>? ProductList { get; set; }
        public string? SearchKey { get; set; }
    }
}
