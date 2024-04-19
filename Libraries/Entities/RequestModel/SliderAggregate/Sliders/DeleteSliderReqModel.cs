using System;

namespace Entities.RequestModel.SliderAggregate.Sliders
{
    public class DeleteSliderReqModel
    {
        public DeleteSliderReqModel(Guid id)
        {
            Id = id;
        }
        public DeleteSliderReqModel()
        {
            
        }
        public Guid Id { get; set; }
    }
}
