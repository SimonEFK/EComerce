namespace HardwareStore.App.Areas.Administration.Models.ProductManagment
{
    using System.ComponentModel.DataAnnotations;

    public class AddImageInputModel
    {
        [RegularExpression(@"^https?:\/\/.*\/.*\.(jpg|jpeg|png|gif|webp|avif)$", ErrorMessage = "Invalid Url Format")]
        public string ImageUrl { get; set; }
    }
}
