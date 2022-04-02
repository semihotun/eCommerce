using Entities.Concrete.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;

namespace Entities.ViewModels.WebViewModel.Home
{
    public class SearchVM
    {
        public IPagedList<Product> ProductList { get; set; }
        public string SearchKey { get; set; }
    }
}
