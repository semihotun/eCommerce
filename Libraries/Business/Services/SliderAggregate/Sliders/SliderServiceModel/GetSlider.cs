namespace Business.Services.SliderAggregate.Sliders.SliderServiceModel
{
    public class GetSlider
    {
        public GetSlider(int id)
        {
            Id = id;
        }
        public GetSlider()
        {
        }
        public int Id { get; set; }
    }
}
