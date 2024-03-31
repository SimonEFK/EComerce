namespace HardwareStore.App.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    public class UserRegisterFormModel
    {
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(ConfirmPassword))]
        public string Password { get; set; }

        [Required(ErrorMessage = "The Confirm Password field is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
