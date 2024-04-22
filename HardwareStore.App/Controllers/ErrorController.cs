namespace HardwareStore.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("Error")]
    public class ErrorController : Controller
    {
        [HttpGet("{statusCode}")]
        public IActionResult PageNotFound(int statusCode)
        {
            
            return View("PageNotFound");
        }

        [HttpGet("BadRequest")]
        public IActionResult BadRequest(string? errorMessage)
        {
            ViewData["Error"] = errorMessage;
            return View("BadRequest");
        }
    }
}
