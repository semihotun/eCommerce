using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.SliderAggregate.Sliders;
using System.Threading.Tasks;

namespace Business.Services.SliderAggregate.Sliders.Commands
{
    public interface ISliderCommandService
    {
        Task<Result<Slider>> InsertSlider(InsertSliderReqModel slider);
        Task<Result> UpdateSlider(UpdateSliderReqModel slider);
        Task<Result> DeleteSlider(DeleteSliderReqModel request);
    }
}
