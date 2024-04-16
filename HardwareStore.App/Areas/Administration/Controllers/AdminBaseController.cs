namespace HardwareStore.App.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static HardwareStore.App.Constants.Constants;

    [Area(Areas.Administration)]
    //[Authorize(Roles = Roles.Admin)]
    public class AdminBaseController : Controller
    {
        
    }
}
