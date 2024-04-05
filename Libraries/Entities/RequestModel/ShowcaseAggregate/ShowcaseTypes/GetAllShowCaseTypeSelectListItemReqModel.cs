namespace Entities.RequestModel.ShowcaseAggregate.ShowcaseTypes
{
    public class GetAllShowCaseTypeSelectListItemReqModel
    {
        public GetAllShowCaseTypeSelectListItemReqModel(int? selectedId = 0)
        {
            SelectedId = selectedId;
        }
        public GetAllShowCaseTypeSelectListItemReqModel()
        {
            
        }
        public int? SelectedId { get; set; }
    }
}
