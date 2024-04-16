namespace HardwareStore.App.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    
    public class AdminController : AdminBaseController
    {
                
        public IActionResult Index()
        {           
            return Redirect("/Administration/ProductManagment");
        }
    }
}
