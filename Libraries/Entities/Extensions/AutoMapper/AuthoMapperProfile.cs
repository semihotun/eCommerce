using AutoMapper;
using Entities.Dtos.ProductAttributeCombinationDALModels;
using Entities.Dtos.ProductDALModels;
namespace Entities.Extensions.AutoMapper
{
    public class AuthoMapperProfile : Profile
    {
        public AuthoMapperProfile()
        {
            CreateMap<ProductDetailDTO.ProductAttributeCombination, ProductAttributeCombinationDTO>().ReverseMap();
        }
    }
}
