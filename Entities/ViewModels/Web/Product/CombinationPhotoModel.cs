using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities.ViewModels.Web
{
    public class CombinationPhotoModel
    {
        public int ProductId { get; set; }
        public int Id { get; set; }
        public string combinations { get; set; }

        public string notcombinations { get; set; }

        
        public int CombinationId { get; set; }

        public int PhotoId { get; set; }

        public ProductPhotoModel productPhoto { get; set; }

        public ProductAttributeCombinationModel ProductAttributeCombination { get; set; }

    }
}