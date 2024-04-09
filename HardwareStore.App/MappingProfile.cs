namespace HardwareStore.App
{
    using AutoMapper;
    using HardwareStore.App.Areas.Administration.Models.CategoryManagment.Category;
    using HardwareStore.App.Areas.Administration.Models.CategoryManagment.Specifications;
    using HardwareStore.App.Areas.Administration.Models.ProductManagment;
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Models.Category;
    using HardwareStore.App.Models.Orders;
    using HardwareStore.App.Models.Product;
    using HardwareStore.App.Models.ProductFilter;
    using HardwareStore.App.Services.Cart;
    using HardwareStore.App.Services.Data.Category;
    using HardwareStore.App.Services.Data.Products.Create;
    using HardwareStore.App.Services.Data.Products.Edit;
    using HardwareStore.App.Services.Orders;
    using HardwareStore.App.Services.ProductReview;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Product, ProductSimplifiedModel>().ForMember(product => product.Image,
                config => config.MapFrom(source => source.Images.FirstOrDefault().FilePath ??
                source.Images.FirstOrDefault().Url))
                .ForMember(product => product.ProductReviewsRatingAvg, config => config.MapFrom(p => p.ProductReviews.Average(r => r.Rating))); ;
                
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
                }).ToList()))
                .ForMember(product=>product.ProductReviewsRatingAvg, config=> config.MapFrom(p=>p.ProductReviews.Average(r=>r.Rating)));

            this.CreateMap<Product, ProductDetailedModel>()
                .ForMember(product => product.Images,
                config => config.MapFrom(source => source.Images.Select(y => y.FilePath ?? y.Url).ToList())).ForMember(x => x.Specifications, cfg => cfg.MapFrom(product => product.Specifications.Select(productSpecValue => new ProductSpecifications
                {
                    Name = productSpecValue.SpecificationValue.Specification.Name,
                    Values = product.Specifications
                        .Where(y => y.SpecificationValue.Specification.Name == productSpecValue.SpecificationValue.Specification.Name)
                        .Select(c => c.SpecificationValue.Value)
                }).ToList())).ForMember(product => product.ProductReviewsRatingAvg, config => config.MapFrom(p => p.ProductReviews.Average(r => r.Rating)));

            this.CreateMap<Specification, SpecificationFilterOption>();
            this.CreateMap<SpecificationValue, SpecificationValueOption>();
            this.CreateMap<Category, CategoryModel>().ForMember(x => x.Image, cfg => cfg.MapFrom(source => source.FilePath ?? source.Url));
            this.CreateMap<Category, CategoryViewModel>().ForMember(x => x.Image, cfg => cfg.MapFrom(source => source.FilePath ?? source.Url));
            this.CreateMap<Category, Tuple<string, int>>();

            this.CreateMap<CreateProductInputModel, CreateProductDTO>();
            this.CreateMap<EditProductInputModel, EditProductDTO>();
            this.CreateMap<Category, CategoryInfoDTO>();
            this.CreateMap<Specification, SpecificationInfoDTO>();
            this.CreateMap<SpecificationValue, SpecificationValueInfoDTO>();
            this.CreateMap<CategoryInfoDTO, CategoryEditInputModel>();
            this.CreateMap<SpecificationInfoDTO, SpecificationCreateInputModel>()
                .ForMember(m => m.Essential, cfg => cfg.MapFrom(x => x.InfoLevel == "Essential" ? true : false));
            this.CreateMap<ProductReview,ProductReviewDTO>();
            this.CreateMap<Product, EditProductDTO>();
            this.CreateMap<Image,EditImageDTO>();
            this.CreateMap<ProductSpecificationValues, ProductSpecificationEdit>()
                .ForMember(x=> x.SpecificationName, cfg=> cfg.MapFrom(x=>x.SpecificationValue.Specification.Name))
                .ForMember(x=> x.ValueName, cfg=> cfg.MapFrom(x=>x.SpecificationValue.Value))
                .ForMember(x=>x.ValueId,cfg=> cfg.MapFrom(x=>x.SpecificationValueId));
            this.CreateMap<EditProductDTO, EditProductInputModel>();
            this.CreateMap<CartProduct,CartProductModel>().ForMember(x => x.Image, cfg => cfg.MapFrom(source => source.Product.Images.FirstOrDefault().FilePath ?? source.Product.Images.FirstOrDefault().Url));

            this.CreateMap<OrderItemInputModel, CreateOrderItemDTO>();
            this.CreateMap<Order, OrderInfoDTO>();
            this.CreateMap<OrderProduct,OrderProductInfoDTO>();
        }
    }
}
