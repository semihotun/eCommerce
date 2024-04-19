using System;

namespace Entities.RequestModel.ShowcaseAggregate.ShowcaseTypes
{
    public class GetAllShowCaseTypeSelectListItemReqModel
    {
        public GetAllShowCaseTypeSelectListItemReqModel(Guid? selectedId)
        {
            SelectedId = selectedId;
        }
        public GetAllShowCaseTypeSelectListItemReqModel()
        {
            
        }
        public Guid? SelectedId { get; set; }
    }
}
