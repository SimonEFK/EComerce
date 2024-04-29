namespace HardwareStore.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    
    public class ErrorController : Controller
    {
        [HttpGet()]
        public IActionResult ErrorHandler(int errorCode,string errorMessage)
        {
            if (errorCode == 404)
            {
                return View("PageNotFound");

            }

            return View("BadRequest",errorMessage);
        }
        
    }
}
