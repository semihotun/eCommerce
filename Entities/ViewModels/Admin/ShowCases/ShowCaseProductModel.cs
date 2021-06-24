
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Entities.ViewModels.Admin
{
    public class ShowCaseProductModel
    {
   
        public int Id { get; set; }

        public int? ShowCaseId { get; set; }

        public int? ProductId { get; set; }

        public string ShowCaseText { get; set; }

        public virtual ProductModel Product { get; set; }

        public virtual ShowCaseModel ShowCase { get; set; }


    }
}
