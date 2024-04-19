using Entities.Concrete;
using System;

namespace Entities.RequestModel.ShowcaseAggregate.ShowcaseServices
{
    public class InsertShowcaseReqModel
    {
        public Guid Id { get; set; }
        public int ShowCaseOrder { get; set; }
        public string ShowCaseTitle { get; set; }
        public Guid ShowCaseType { get; set; }
        public string ShowCaseText { get; set; }
        public InsertShowcaseReqModel()
        {

        }
        public InsertShowcaseReqModel(Guid id, int showCaseOrder, string showCaseTitle, Guid showCaseType, string showCaseText)
        {
            Id = id;
            ShowCaseOrder = showCaseOrder;
            ShowCaseTitle = showCaseTitle;
            ShowCaseType = showCaseType;
            ShowCaseText = showCaseText;
        }
    }
}
