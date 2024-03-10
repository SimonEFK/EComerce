namespace HardwareStore.App.Models.Product
{
    public class ProductSimplifiedModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public decimal? Price { get; set; }


        public int CategoryId { get; set; }

        public double ProductReviewsRatingAvg { get; set; }

    }
}
