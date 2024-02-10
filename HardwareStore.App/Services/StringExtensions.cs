namespace HardwareStore.App.Services
{
    using System.Globalization;

    public static class StringExtensions
    {

        public static string ToTitleCase(this string str)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(str);
        }

    }
}
