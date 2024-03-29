﻿using AutoMapper;
using Entities.Helpers.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
namespace eCommerce.Extensions
{
    public static class AutoMapperExtension
    {
        public static void AutoMapperSettings(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AuthoMapperProfile());
                mc.AddProfile(new AdminAuthoMapperProfile());
            });
            IMapper mapper = AutoMapperConfig.Get().CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
