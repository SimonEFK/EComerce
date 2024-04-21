namespace HardwareStore.App.Constants
{
    using HardwareStore.App.Data.Models;

    public static class ModelConstraints
    {
        public static class Address
        {
            public const int CountryMaxLength = 100;
            public const int RegionMaxLength = 100;
            public const int CityMaxLength = 100;
            public const int PostalCodeMaxLength = 100;
            public const int DescriptionMaxLength = 300;
            public const int PhoneMaxLength = 20;
        }

        public static class Category
        {
            public const int NameMaxLength = 100;
        }

        public static class Manufacturer
        {
            public const int NameMaxLength = 100;
        }

        public static class Product
        {
            public const int NameMaxLength = 150;
            public const int NameDetailedMaxLength = 200;
        }

        public static class ProductReview
        {
            public const int RatingMaxValue = 5;
            public const int ReviewMaxLength = 300;
        }

        public static class Specification
        {
            public const int NameMaxLength = 150;
            public const int InfoLevelMaxLength = 20;
        }
        public static class SpecificationValue
        {
            public const int ValueMaxLength = 100;
            public const int MetricMaxLength = 30;
        }
        public static class Image
        {
            public const string ImageRegexPattern = @"^https?:\/\/.*\/.*\.(jpg|jpeg|png|gif|webp|avif)$";
        }
    }
}
