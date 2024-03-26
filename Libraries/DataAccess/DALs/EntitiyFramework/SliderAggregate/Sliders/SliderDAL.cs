using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
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
