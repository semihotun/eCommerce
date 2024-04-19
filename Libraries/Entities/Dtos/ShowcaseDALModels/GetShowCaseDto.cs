using System;

namespace Entities.Dtos.ShowcaseDALModels
{
    public class GetShowCaseDto
    {
        public GetShowCaseDto(Guid showCaseId)
        {
            ShowCaseId = showCaseId;
        }
        public GetShowCaseDto()
        {
        }
        public Guid ShowCaseId { get; set; }
    }
}
