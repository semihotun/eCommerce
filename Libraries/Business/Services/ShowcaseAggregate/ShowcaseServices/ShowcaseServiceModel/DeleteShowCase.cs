namespace Business.Services.ShowcaseAggregate.ShowcaseServices.ShowcaseServiceModel
{
    public class DeleteShowCase
    {
        public DeleteShowCase(int id)
        {
            Id = id;
        }
        public DeleteShowCase()
        {
        }
        public int Id { get; set; }
    }
}
