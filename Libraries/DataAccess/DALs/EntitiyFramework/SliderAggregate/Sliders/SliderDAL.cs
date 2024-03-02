using eCommerce.Core.DataAccess;
using eCommerce.Core.DataAccess.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccess.Context;
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
