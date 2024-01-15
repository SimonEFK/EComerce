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
                .ForMember(x => x.Specifications, cfg => cfg.MapFrom(product => product.Specifications.Where(s => s.SpecificationValue.Specification.InfoLevel == "Essential").Select(productSpecValue => new ProductSpecifications
                {
                    Name = productSpecValue.SpecificationValue.Specification.Name,
                    Values = product.Specifications
                        .Where(y => y.SpecificationValue.Specification.Name == productSpecValue.SpecificationValue.Specification.Name)
                        .Select(c => c.SpecificationValue.Value)
                }).ToList()));

            this.CreateMap<Product, ProductDetailedModel>()
                .ForMember(product => product.Images,
                config => config.MapFrom(source => source.Images.Select(y => y.FilePath ?? y.Url).ToList())).ForMember(x => x.Specifications, cfg => cfg.MapFrom(product => product.Specifications.Select(productSpecValue => new ProductSpecifications
                {
                    Name = productSpecValue.SpecificationValue.Specification.Name,
                    Values = product.Specifications
                        .Where(y => y.SpecificationValue.Specification.Name == productSpecValue.SpecificationValue.Specification.Name)
                        .Select(c => c.SpecificationValue.Value)
                }).ToList())); ;

            this.CreateMap<Specification, SpecificationFilterOption>();
            this.CreateMap<SpecificationValue, SpecificationValueOption>();

            this.CreateMap<Category, CategoryModel>().ForMember(x => x.Image, cfg => cfg.MapFrom(source => source.FilePath ?? source.Url));
            this.CreateMap<Category, Tuple<string, int>>();

        }
    }
}
