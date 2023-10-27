namespace HardwareStore.App
{
    using AutoMapper;
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Models.Category;
    using HardwareStore.App.Models.Product;
    using HardwareStore.App.Models.ProductFilter;

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


            this.CreateMap<Product, ProductDetailedModel>()
                .ForMember(product => product.ImagesUrls,
                config => config.MapFrom(source => source.Images.Select(y => y.FilePath ?? y.Url).ToList()));

            this.CreateMap<Specification, SpecificationFilterOption>();
            this.CreateMap<SpecificationValue, SpecificationValueOption>();

            this.CreateMap<Category, CategoryModel>().ForMember(x => x.Image, cfg => cfg.MapFrom(source => source.FilePath ?? source.Url));

        }
    }
}
