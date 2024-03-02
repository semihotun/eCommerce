using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.SliderAggregate;
namespace DataAccess.DALs.EntitiyFramework.SliderAggregate.Sliders
{
    public class SliderDAL : EfEntityRepositoryBase<Slider, eCommerceContext>, ISliderDAL
    {
        public SliderDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
