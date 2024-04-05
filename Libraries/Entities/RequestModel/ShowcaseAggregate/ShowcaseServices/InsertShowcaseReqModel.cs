using Entities.Concrete;

namespace Entities.RequestModel.ShowcaseAggregate.ShowcaseServices
{
    public class InsertShowcaseReqModel
    {
        public int Id { get; set; }
        public int ShowCaseOrder { get; set; }
        public string ShowCaseTitle { get; set; }
        public int ShowCaseType { get; set; }
        public string ShowCaseText { get; set; }
        public InsertShowcaseReqModel()
        {
            
        }
        public InsertShowcaseReqModel(int id, int showCaseOrder, string showCaseTitle, int showCaseType, string showCaseText)
        {
            Id = id;
            ShowCaseOrder = showCaseOrder;
            ShowCaseTitle = showCaseTitle;
            ShowCaseType = showCaseType;
            ShowCaseText = showCaseText;
        }
    }
}
