namespace HardwareStore.App.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static HardwareStore.App.Constants.ModelConstraints.Address;

    public class Address
    {

        public int Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

        [Required]
        [MaxLength(CountryMaxLength)]
        public string Country { get; set; }

        [MaxLength(RegionMaxLength)]
        public string Region { get; set; }

        [Required]
        [MaxLength(CityMaxLength)]
        public string City { get; set; }

        [Required]
        [MaxLength(PostalCodeMaxLength)]

        public string PostalCode { get; set; }

        [Required]
        [MaxLength(PhoneMaxLength)]
        public string Phone { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }

    }
}
