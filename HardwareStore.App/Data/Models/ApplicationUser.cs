namespace HardwareStore.App.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {

        public ICollection<ProductReview> ProductReviews { get; set; } = new HashSet<ProductReview>();

        public ICollection<Address> Addresses { get; set; } = new HashSet<Address>();

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();

        public Cart Cart { get; set; }

    }
}
