namespace HardwareStore.App.Services.Data.Products
{
    public class ProductCreationStatus
    {
        public int? Id { get; set; } = null;
        public bool IsSucssessfull { get; set; } = true;
        public List<string> Messages { get; set; } = new List<string>();
    }
}
