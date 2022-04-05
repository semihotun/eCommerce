using AutoMapper;


namespace Entities.Helpers.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Get()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AuthoMapperProfile());
                mc.AddProfile(new AdminAuthoMapperProfile());
            });
            return mappingConfig;
        }
    }
}
