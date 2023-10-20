﻿namespace HardwareStore.App
{
    using AutoMapper;
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Models.Product;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Product, ProductExtendedModel>()
                .ForMember(product => product.ImageUrl,
                config => config.MapFrom(source => source.Images.FirstOrDefault().FilePath ??
                source.Images.FirstOrDefault().Url))
                .ForMember(x => x.Specifications, cfg => cfg.MapFrom(c => c.Specifications.Where(x => x.SpecificationValue.Specification.InfoLevel == "Essential")));

            this.CreateMap<ProductSpecificationValues, ProductSpecifications>().ForMember(x => x.Name, cfg => cfg.MapFrom(c => c.SpecificationValue.Specification.Name))
                .ForMember(x => x.Value, cfg => cfg.MapFrom(x => x.SpecificationValue.Value));

        }
    }
}