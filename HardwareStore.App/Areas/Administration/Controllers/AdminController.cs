namespace HardwareStore.App.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Area("administration")]
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
                
        public IActionResult Index()
        {           
            return Redirect("/Administration/ProductManagment");
        }
    }
}
