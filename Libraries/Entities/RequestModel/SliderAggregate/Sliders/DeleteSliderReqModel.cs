namespace Entities.RequestModel.SliderAggregate.Sliders
{
    public class DeleteSliderReqModel
    {
        public DeleteSliderReqModel(int id)
        {
            Id = id;
        }
        public DeleteSliderReqModel()
        {
            
        }
        public int Id { get; set; }
    }
}
