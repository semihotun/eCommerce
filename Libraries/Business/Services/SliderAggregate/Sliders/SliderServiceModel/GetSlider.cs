namespace Business.Services.SliderAggregate.Sliders.SliderServiceModel
{
    public class GetSlider
    {
        public GetSlider(int ıd)
        {
            Id = ıd;
        }
        public GetSlider()
        {
        }
        public int Id { get; set; }
    }
}
