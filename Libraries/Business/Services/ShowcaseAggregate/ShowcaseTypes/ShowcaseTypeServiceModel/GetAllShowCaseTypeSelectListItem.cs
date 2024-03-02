namespace Business.Services.ShowcaseAggregate.ShowcaseTypes.ShowcaseTypeServiceModel
{
    public class GetAllShowCaseTypeSelectListItem
    {
        public GetAllShowCaseTypeSelectListItem(int? selectedId = 0)
        {
            SelectedId = selectedId;
        }
        public GetAllShowCaseTypeSelectListItem()
        {
        }
        public int? SelectedId { get; set; }
    }
}
