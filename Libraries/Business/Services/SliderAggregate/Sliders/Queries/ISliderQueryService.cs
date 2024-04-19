using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.SliderAggregate.Sliders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.SliderAggregate.Sliders.Queries
{
    public interface ISliderQueryService
    {
        Task<Result<List<Slider>>> GetAllSlider();
        Task<Result<Slider>> GetSlider(GetSliderReqModel request);
    }
}
