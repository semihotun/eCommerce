namespace Entities.Concrete
{
    using Core.SeedWork;

    public class Slider : BaseEntity, IEntity
    {
        public string SliderImage { get; set; }
        public string SliderHeading { get; set; }
        public string SliderText { get; set; }
        public string SliderLink { get; set; }
    }
}
