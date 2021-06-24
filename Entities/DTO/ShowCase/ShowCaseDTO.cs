using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO.ShowCase
{
    public class ShowCaseDTO
    {
        public int Id { get; set; }
        public int ShowCaseOrder { get; set; }
        public string ShowCaseTitle { get; set; }
        public int ShowCaseType { get; set; }
        public string ShowCaseText { get; set; }
        public List<ShowCaseProductDTO> ShowCaseProductList { get; set; }
    }
}
