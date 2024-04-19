using System;

namespace Entities.RequestModel.SliderAggregate.Sliders
{
    public class GetSliderReqModel
    {
        public GetSliderReqModel(Guid id)
        {
            Id = id;
        }
        public GetSliderReqModel()
        {
            
        }
        public Guid Id { get; set; }
    }
}
