﻿using AutoMapper;
namespace Entities.Helpers.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Get()
        {
            return new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AuthoMapperProfile());
                mc.AddProfile(new AdminAuthoMapperProfile());
            });
        }
    }
}
