namespace Entities.RequestModel.CategoriesAggregate.Categories
{
    public class DeleteNodesReqModel
    {
        public DeleteNodesReqModel()
        {

        }
        public DeleteNodesReqModel(string idsString)
        {
            IdsString = idsString;
        }
        public string IdsString { get; set; }
    }
}
