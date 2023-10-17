namespace HardwareStore.App.Data.Models
{


    public class Cart
    {
        public Cart()
        {
            Products = new HashSet<CartProduct>();
        }

        public int Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

        public ICollection<CartProduct> Products { get; set; }
    }
}
