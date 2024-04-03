namespace HardwareStore.App.Constants
{
    using HardwareStore.App.Data.Models;

    public static class Constants
    {
        public static class ErrorMessages
        {
            public const string InvalidProductId = "Product with Id:\"{0}\" is Invalid";
            public const string InvalidUserCart = "User with Id:\"{0}\" dosen't have cart";
            public const string InvalidVlaueId = "Invalid Value with Id:\"{0}\"";

            public const string CategoryExsist = "Category Name:\"{0}\" already exsist";
            public const string CategoryDosentExsist = "Category doesn't exsist";
            public const string SpecificationExsist = "Specification:\"{0}\" already exsist in Category \"{1}\"";
            public const string SpecificationDoesentExsist = "Specification doesn't exsist";
            public const string SpecificationValueExsist = "Value:\"{2}\" already exsist in Category:\"{0}\" Specification:\"{1}\"";

            public const string InvalidReviewId = "Review with Id:\"{0}\" is invalid";
        }
        public static class Areas
        {
            public const string Administration = "administration";
        }
        public static class Roles
        {
            public const string Admin = "admin";
        }
    }
}
