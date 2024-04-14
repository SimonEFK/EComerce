namespace HardwareStore.App.Services
{
    using PayPal.Api;

    public interface IPayPalService
    {
        APIContext GetAPIContext();
    }
}