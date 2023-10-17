namespace HardwareStore.App.Data.Models
{
    public class Image
    {
        public string Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public string? FilePath { get; set; }

        public string Url { get; set; }

        public bool? MainImage { get; set; }

    }
}