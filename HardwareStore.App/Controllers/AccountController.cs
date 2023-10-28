namespace HardwareStore.App.Controllers
{
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Models.Account;
    using HardwareStore.App.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    

    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private ICartService cartService;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ICartService cartService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.cartService = cartService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            var model = new UserRegisterFormModel();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserRegisterFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            };

            var user = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                TempData["RegisterMessage"] = "Account Created Succssesfully";
                await cartService.CreateCart(user);
                return RedirectToAction(nameof(Login));
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            ViewBag.Message = "Failed to Create Account";


            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            var loginModel = new UserLoginFormModel();
            ViewBag.Message = TempData["RegisterMessage"];
            return View(loginModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginFormModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            var user = await userManager.FindByEmailAsync(loginModel.Email);

            if (user is not null)
            {
                var result = await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ViewBag.Message = "Unssecssesful Login";
            return View(loginModel);

        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
