namespace Entities.ViewModels.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Http;
    using X.PagedList;

    public class ProductPhotoModel
    {
        public int Id { get; set; }
        public string ProductPhotoName { get; set; }
        public int ProductId { get; set; }
        public IEnumerable<IFormFile> ResimDosya { get; set; }
        public List<ProductPhotoModel> ProductPhotoList { get; set; }
        public List<ProductModel> Product { get; set; }
        public int ProductAttributeCombinationId { get; set; }


        
    }
}
