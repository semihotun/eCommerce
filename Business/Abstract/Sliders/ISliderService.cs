using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Abstract.Sliders
{
    public interface ISliderService
    {
        Task<IDataResult<IList<Slider>>> GetAllSlider();
        Task<IResult> InsertSlider(Slider slider);
        Task<IResult> DeleteSlider(int id);
        Task<IDataResult<Slider>> GetSlider(int id);
        Task<IResult> UpdateSlider(Slider slider);
    }
}
