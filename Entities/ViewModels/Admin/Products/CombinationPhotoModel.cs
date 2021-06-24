using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities.ViewModels.Admin
{
    public class CombinationPhotoModel
    {
        public int ProductId { get; set; }
        public int Id { get; set; }
        public string Combinations { get; set; }

        public string NotCombinations { get; set; }

        
        public int CombinationId { get; set; }

        public int PhotoId { get; set; }

        public ProductPhotoModel ProductPhoto { get; set; }

        public ProductAttributeCombinationModel ProductAttributeCombination { get; set; }

    }
}