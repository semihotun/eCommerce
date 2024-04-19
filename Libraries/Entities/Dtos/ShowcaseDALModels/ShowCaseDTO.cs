using System;
using System.Collections.Generic;
namespace Entities.Dtos.ShowcaseDALModels
{
    public class ShowCaseDTO
    {
        public Guid Id { get; set; }
        public int ShowCaseOrder { get; set; }
        public string ShowCaseTitle { get; set; }
        public Guid ShowCaseType { get; set; }
        public string ShowCaseText { get; set; }
        public IEnumerable<ShowCaseProductDTO> ShowCaseProductList { get; set; }
    }
}
