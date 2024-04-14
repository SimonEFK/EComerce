namespace HardwareStore.App.Services
{
    using PayPal.Api;

    public class PayPalService : IPayPalService
    {
        private readonly string clientId;
        private readonly string clientSecret;

        private DateTime expiryTime;
        private string token;
        private APIContext payPalAPIContext;
        private readonly IConfiguration configuration;

        public PayPalService(IConfiguration configuration, APIContext payPalAPIContext)
        {
            this.clientId = configuration.GetValue<string>("PayPal:ClientId");
            this.clientSecret = configuration.GetValue<string>("PayPal:Secret");
            this.payPalAPIContext = payPalAPIContext;
        }

        public APIContext GetAPIContext()
        {
            
            var config = GetConfig();
            var token = GetAccessToken(config);

            this.payPalAPIContext.Config = config;
            this.payPalAPIContext.AccessToken = token;
            
            return this.payPalAPIContext;
        }

        private Dictionary<string, string> GetConfig()
        {
            var config = new Dictionary<string, string>
            {
                    {"clientId" , this.clientId },
                    {"clientSercret" , this.clientSecret },
                    { "mode", "sandbox" },
                    { "connectionTimeout", "30000" },
                    { "requestRetries", "1" },
            };
            return config;
        }

        private string GetAccessToken(Dictionary<string, string> config)
        {
            if (string.IsNullOrEmpty(this.token) || DateTime.UtcNow >= expiryTime)
            {

                var tokenCredential = new OAuthTokenCredential(this.clientId, this.clientSecret, config);
                this.token = tokenCredential.GetAccessToken();
                this.expiryTime = DateTime.UtcNow.AddHours(8).AddMinutes(-5);
            }

            return this.token;
        }

    }

}

