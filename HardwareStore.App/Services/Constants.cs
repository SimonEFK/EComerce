namespace HardwareStore.App.Services
{
    public static class Constants
    {
        public static class ErrorMessages
        {
            public const string CategoryExsist = "Category Name:\"{0}\" already exsist";
            public const string CategoryDosentExsist = "Category doesn't exsist";
            public const string SpecificationExsist = "Specification:\"{0}\" already exsist in Category \"{1}\"";
            public const string SpecificationDoesentExsist = "Specification doesn't exsist";
            public const string SpecificationValueExsist = "Value:\"{2}\" already exsist in Category:\"{0}\" Specification:\"{1}\"";
        }
    }
}
