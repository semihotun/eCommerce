namespace Business.Services.ShowcaseAggregate.ShowcaseServices.ShowcaseServiceModel
{
    public class GetShowcase
    {
        public GetShowcase(int id)
        {
            Id = id;
        }
        public GetShowcase()
        {
        }
        public int Id { get; set; }
    }
}
