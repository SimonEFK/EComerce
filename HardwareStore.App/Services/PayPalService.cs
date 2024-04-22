namespace HardwareStore.App.Services
{
    using PayPal.Api;

    public class PayPalService : IPayPalService
    {

        private DateTime expiryTime;
        private string token;


        public Dictionary<string, string> PayPalConfig(IConfiguration configuration)
        {
            var clientId = configuration.GetValue<string>("PayPal:ClientId");
            var clientSecret = configuration.GetValue<string>("PayPal:Secret");

            if (string.IsNullOrEmpty(clientSecret) || string.IsNullOrEmpty(clientId))
            {
                throw new InvalidOperationException("PayPal credentials are missing. Please configure them.");
            }

            var config = new Dictionary<string, string>
            {
                    {"clientId" , clientId },
                    {"clientSercret" , clientSecret },
                    { "mode", "sandbox" },
                    { "connectionTimeout", "30000" },
                    { "requestRetries", "1" },
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

