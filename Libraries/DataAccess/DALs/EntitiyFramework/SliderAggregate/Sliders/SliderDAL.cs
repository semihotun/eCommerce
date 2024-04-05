using Core.DataAccess.EntitiyFramework;
using DataAccess.Context;
using Entities.Concrete.SliderAggregate;
namespace DataAccess.DALs.EntitiyFramework.SliderAggregate.Sliders
{
    public class SliderDAL : EfEntityRepositoryBase<Slider, ECommerceContext>, ISliderDAL
    {
        public SliderDAL(ECommerceContext context) : base(context)
        {
        }
    }
}
