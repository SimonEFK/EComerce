namespace HardwareStore.App.Models.UserProfile
{
    using System.ComponentModel.DataAnnotations;

    public class CreateAddressInputModel
    {
        [Required]
        public string City { get; set; }

        [Required]        
        public string Region { get; set; }

        [Required]        
        public string PostalCode { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        public string? Description { get; set; }
    }
}