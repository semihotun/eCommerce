namespace Entities.RequestModel.SliderAggregate.Sliders
{
    public class GetSliderReqModel
    {
        public GetSliderReqModel(int id)
        {
            Id = id;
        }
        public GetSliderReqModel()
        {
            
        }
        public int Id { get; set; }
    }
}
