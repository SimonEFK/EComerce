namespace HardwareStore.App.Services
{
    using System.Collections.Generic;

    public interface IPayPalService
    {
        string GetAccessToken(Dictionary<string, string> config);

        Dictionary<string, string> PayPalConfig();
    }
}