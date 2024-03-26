using Business.Services.SliderAggregate.Sliders.SliderServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.SliderAggregate;
using Entities.ViewModels.AdminViewModel.AdminSlider;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.SliderAggregate.Sliders
{
    public interface ISliderService
    {
        Task<Result<List<Slider>>> GetAllSlider();
        Task<Result> InsertSlider(SliderCreateOrUpdateVM slider);
        Task<Result> DeleteSlider(DeleteSlider request);
        Task<Result<Slider>> GetSlider(GetSlider request);
        Task<Result> UpdateSlider(SliderCreateOrUpdateVM slider);
    }
}
