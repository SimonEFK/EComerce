namespace HardwareStore.App.Services
{
    using Microsoft.AspNetCore.Http;
    using System.IO;

    public class UrlValidationService : IUrlValidationService
    {


        public bool UrlIsValidImage(string url)
        {
            string[] validExtensions = { ".jpg", ".jpeg", ".png" };
            var urlIsValid = UrlIsValid(url);
            if (urlIsValid)
            {
                var uri = new Uri(url);
                var extension = Path.GetExtension(uri.LocalPath);
                if (validExtensions.Contains(extension))
                {
                    return false;
                }
            }
            return true;
        }
        public bool UrlIsValid(string url)
        {
            var result = UrlValidation(url);
            return result;
        }
        private bool UrlValidation(string url)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult) &&
              (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            return result;
        }
    }
}
