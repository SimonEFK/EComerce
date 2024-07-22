namespace HardwareStore.App.Configurations
{
    public class PaypalSettings
    {
        public string Culture { get; set; }

        public string Mode { get; set; }

        public string ConnectionTimeOut { get; set; }

        public string RequestRetries { get; set; }
        
        public string Currency { get; set; }

        public string ReturnUrl { get; set; }

        public string CancelUrl { get; set; }
    }
}
