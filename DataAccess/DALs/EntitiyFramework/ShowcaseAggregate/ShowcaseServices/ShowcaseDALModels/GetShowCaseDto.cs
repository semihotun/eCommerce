using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowcaseServices.ShowcaseDALModels
{
    public class GetShowCaseDto
    {
        public GetShowCaseDto(int showCaseId)
        {
            ShowCaseId = showCaseId;
        }

        public int ShowCaseId { get; set; }
    }
}
