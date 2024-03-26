namespace Business.Services.ShowcaseAggregate.ShowCaseProducts.ShowCaseProductServiceModel
{
    public class DeleteShowCaseProduct
    {
        public DeleteShowCaseProduct(int id)
        {
            Id = id;
        }
        public DeleteShowCaseProduct()
        {
        }
        public int Id { get; set; }
    }
}
