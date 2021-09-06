
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Entities.ViewModels.Web.Search
{
    public class SearchModel
    {
        public IPagedList<Product> ProductList { get; set; }
        public string SearchKey { get; set; }

    }
}
