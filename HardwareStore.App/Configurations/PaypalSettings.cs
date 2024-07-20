namespace HardwareStore.App.Configurations
{
    public class PaypalSettings
    {
        public string Culture { get; set; }

        public string Mode { get; set; }

        public int ConnectionTimeOut { get; set; }

        public string RequestRetries { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string Currency { get; set; }
    }
}
