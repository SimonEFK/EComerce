namespace HardwareStore.App.Services
{
    public interface IUrlValidationService
    {
        bool UrlIsValid(string url);
        bool UrlIsValidImage(string url);
    }
}
