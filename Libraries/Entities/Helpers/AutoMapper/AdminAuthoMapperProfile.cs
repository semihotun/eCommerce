﻿using AutoMapper;
using Entities.Concrete.BrandAggregate;
using Entities.Concrete.CategoriesAggregate;
using Entities.Concrete.PhotoAggregate;
using Entities.Concrete.ProductAggregate;
using Entities.Concrete.ShowcaseAggregate;
using Entities.Concrete.SliderAggregate;
using Entities.Concrete.SpeficationAggregate;
using Entities.DTO;
using Entities.DTO.Product;
using Entities.DTO.ShowCase;
using Entities.Others;
using Entities.ViewModels.AdminViewModel.AdminProduct;
using Entities.ViewModels.AdminViewModel.AdminSlider;
using Entities.ViewModels.AdminViewModel.Showcase;
using Entities.ViewModels.AdminViewModel.SpeficationAttribute;
namespace Entities.Helpers.AutoMapper
{
    public class AdminAuthoMapperProfile : Profile
    {
        public AdminAuthoMapperProfile()
        {
            CreateMap<ProductShipmentInfo, ProductShipmentInfo>().ForMember(x => x.Id, mo => mo.Ignore());
            CreateMap<Product, Product>().ForMember(x => x.Id, mo => mo.Ignore());
            CreateMap<SpecificationAttribute, SpecificationAttribute>().ForMember(x => x.Id, mo => mo.Ignore());
            CreateMap<Brand, Brand>().ForMember(x => x.Id, mo => mo.Ignore());
            CreateMap<ProductAttributeMapping, ProductAttributeMapping>().ForMember(x => x.Id, mo => mo.Ignore());
            CreateMap<PredefinedProductAttributeValue, PredefinedProductAttributeValue>().ForMember(x => x.Id, mo => mo.Ignore());
            CreateMap<ProductSeo, ProductSeo>().ForMember(x => x.Id, mo => mo.Ignore());
            CreateMap<Slider, Slider>().ForMember(x => x.Id, mo => mo.Ignore());
            CreateMap<ShowCase, ShowCase>().ForMember(x => x.Id, mo => mo.Ignore());
            CreateMap<ShowCaseProduct, ShowCaseProduct>().ForMember(x => x.Id, mo => mo.Ignore());
            CreateMap<CombinationPhoto, CombinationPhoto>().ForMember(x => x.Id, mo => mo.Ignore());
            CreateMap<SpecificationAttributeOption, SpecificationAttributeOption>().ForMember(x => x.Id, mo => mo.Ignore());
            CreateMap<ProductAttribute, ProductAttribute>().ForMember(x => x.Id, mo => mo.Ignore());
            CreateMap<ProductAttributeValue, ProductAttributeValue>().ForMember(x => x.Id, mo => mo.Ignore());
            CreateMap<Category, Category>().ForMember(x => x.Id, mo => mo.Ignore());
            CreateMap<ShowCaseDTO, ShowCase>();
            CreateMap<Product, ProductDataTableJson>().ReverseMap();
            CreateMap<MappingAttrModel, MappingAttrXml>().ReverseMap();
            CreateMap<SliderCreateOrUpdateVM, Slider>().ReverseMap();
            CreateMap<ShowCaseCreateOrUpdateVM, ShowCase>().ReverseMap();
            CreateMap<SpecificationAttributeVM, SpecificationAttribute>().ReverseMap();
            CreateMap<SpecificationAttributeOptionVM, SpecificationAttributeOption>().ReverseMap();
            CreateMap<Product, ProductVM>().ReverseMap();
            CreateMap<ProductStockCreateOrUpdateVM, ProductStock>().ReverseMap();
            CreateMap<ProductAttributeCombinationVM, ProductAttributeCombination>().ReverseMap();
        }
    }
}
