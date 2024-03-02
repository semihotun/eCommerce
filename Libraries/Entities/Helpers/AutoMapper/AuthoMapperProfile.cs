using AutoMapper;
using Entities.DTO.Product;
using Entities.DTO.ProductAttributeCombinations;
namespace Entities.Helpers.AutoMapper
{
    public class AuthoMapperProfile : Profile
    {
        public AuthoMapperProfile()
        {
            CreateMap<ProductDetailDTO.ProductAttributeCombination, ProductAttributeCombinationDTO>().ReverseMap();
        }
    }
}
