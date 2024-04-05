using Core.Utilities.Results;
using Entities.Concrete.SliderAggregate;
using Entities.RequestModel.SliderAggregate.Sliders;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.SliderAggregate.Sliders
{
    public interface ISliderService
    {
        Task<Result<Slider>> InsertSlider(InsertSliderReqModel slider);
        Task<Result> UpdateSlider(UpdateSliderReqModel slider);
        Task<Result> DeleteSlider(DeleteSliderReqModel request);
        Task<Result<List<Slider>>> GetAllSlider();
        Task<Result<Slider>> GetSlider(GetSliderReqModel request);
    }
}