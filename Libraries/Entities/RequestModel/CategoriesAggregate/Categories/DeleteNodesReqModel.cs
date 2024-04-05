namespace Entities.RequestModel.CategoriesAggregate.Categories
{
    public class DeleteNodesReqModel
    {
        public DeleteNodesReqModel()
        {
            
        }
        public DeleteNodesReqModel(string values)
        {
            Values = values;
        }
        public string Values { get; set; }
    }
}
