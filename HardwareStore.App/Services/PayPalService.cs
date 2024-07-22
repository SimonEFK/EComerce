namespace HardwareStore.App.Services
{
    using HardwareStore.App.Configurations;
    using Microsoft.Extensions.Options;
    using PayPal.Api;
    using System.Configuration;

    public class PayPalService : IPayPalService
    {

        private DateTime expiryTime;
        private string token;
        private readonly IOptions<PaypalSettings> settings;

        public PayPalService(IOptions<PaypalSettings> settings)
        {
            this.settings = settings;
        }

        public Dictionary<string, string> PayPalConfig()
        {

            var clientSecret = Environment.GetEnvironmentVariable("Paypal_ClientSecret");
            var clientId = Environment.GetEnvironmentVariable("Paypal_ClientId");
            var mode = this.settings.Value.Mode;
            var connectionTimeout = this.settings.Value.ConnectionTimeOut.ToString();
            var requestRetries = this.settings.Value.RequestRetries;

            if (string.IsNullOrEmpty(clientSecret) || string.IsNullOrEmpty(clientId))
            {
                throw new InvalidOperationException("PayPal credentials are missing. Please configure them.");
            }

            var config = new Dictionary<string, string>
            {
                    {"clientId" , clientId },
                    {"clientSercret" , clientSecret },
                    { "mode", mode },
                    { "connectionTimeout", connectionTimeout },
                    { "requestRetries", requestRetries },
            };
            return config;
        }

        public string GetAccessToken(Dictionary<string, string> config)
        {
            if (string.IsNullOrEmpty(this.token) || DateTime.UtcNow >= expiryTime)
            {

                var tokenCredential =
                new OAuthTokenCredential(config["clientId"], config["clientSercret"]);
                this.token = tokenCredential.GetAccessToken();
                this.expiryTime = DateTime.UtcNow.AddHours(8).AddMinutes(-5);

            }

            return this.token;
        }

    }

}

