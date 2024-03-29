namespace Entities.Concrete.SliderAggregate
{
    using Entities.Concrete;
    public class Slider : BaseEntity
    {
        public string SliderImage { get; set; }
        public string SliderHeading { get; set; }
        public string SliderText { get; set; }
        public string SliderLink { get; set; }
    }
}
