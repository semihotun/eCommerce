namespace DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowcaseServices.ShowcaseDALModels
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
