namespace Business.Services.ShowcaseAggregate.ShowcaseServices.ShowcaseServiceModel
{
    public class GetShowcase
    {
        public GetShowcase(int ıd)
        {
            Id = ıd;
        }
        public GetShowcase()
        {
        }
        public int Id { get; set; }
    }
}
