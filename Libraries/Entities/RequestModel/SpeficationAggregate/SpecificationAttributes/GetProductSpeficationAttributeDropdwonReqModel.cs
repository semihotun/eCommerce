namespace Entities.RequestModel.SpeficationAggregate.SpecificationAttributes
{
    public class GetProductSpeficationAttributeDropdwonReqModel
    {
        public GetProductSpeficationAttributeDropdwonReqModel(int selectedId = 0)
        {
            SelectedId = selectedId;
        }
        public int SelectedId { get; set; }
        public GetProductSpeficationAttributeDropdwonReqModel()
        {
            
        }
    }
}
