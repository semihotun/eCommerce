namespace Entities.RequestModel.ProductAggregate.ProductStockTypes
{
    public class GetAllProductStockTypeReqModel
    {
        public int SelectedId { get; set; }
        public GetAllProductStockTypeReqModel()
        {
            
        }
        public GetAllProductStockTypeReqModel(int selectedId = 0)
        {
            SelectedId = selectedId;
        }
    }
}
