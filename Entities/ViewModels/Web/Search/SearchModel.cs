
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.ViewModels.Web.Search
{
    public class SearchModel
    {
        public List<Product> ProductList { get; set; }
        public string SearchKey { get; set; }

    }
}
