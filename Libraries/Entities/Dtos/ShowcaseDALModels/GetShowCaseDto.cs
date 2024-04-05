namespace Entities.Dtos.ShowcaseDALModels
{
    public class GetShowCaseDto
    {
        public GetShowCaseDto(int showCaseId)
        {
            ShowCaseId = showCaseId;
        }
        public GetShowCaseDto()
        {
        }
        public int ShowCaseId { get; set; }
    }
}
