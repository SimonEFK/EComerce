namespace HardwareStore.App.Services
{
    using Microsoft.Extensions.Configuration;
    using PayPal.Api;
    using System.Collections.Generic;

    public interface IPayPalService
    {
        string GetAccessToken(Dictionary<string, string> config);        
        Dictionary<string, string> PayPalConfig(IConfiguration configuration);
    }
}