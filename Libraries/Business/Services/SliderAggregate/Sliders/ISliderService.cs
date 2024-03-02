using Business.Services.SliderAggregate.Sliders.SliderServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.SliderAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.SliderAggregate.Sliders
{
    public interface ISliderService
    {
        Task<IDataResult<IList<Slider>>> GetAllSlider();
        Task<IResult> InsertSlider(Slider slider);
        Task<IResult> DeleteSlider(DeleteSlider request);
        Task<IDataResult<Slider>> GetSlider(GetSlider request);
        Task<IResult> UpdateSlider(Slider slider);
    }
}
