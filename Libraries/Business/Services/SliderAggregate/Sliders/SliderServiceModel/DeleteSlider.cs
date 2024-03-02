namespace Business.Services.SliderAggregate.Sliders.SliderServiceModel
{
    public class DeleteSlider
    {
        public DeleteSlider(int id)
        {
            Id = id;
        }
        public DeleteSlider()
        {
        }
        public int Id { get; set; }
    }
}
