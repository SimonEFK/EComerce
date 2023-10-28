namespace HardwareStore.App.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    public class UserLoginFormModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
