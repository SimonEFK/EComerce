namespace HardwareStore.App.Controllers
{
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Models.Account;
    using HardwareStore.App.Services.Cart;
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

            var userExsist = userManager.Users.FirstOrDefault(x => x.Email == model.Email);

            if (userExsist != null)
            {
                ModelState.AddModelError("Email", "Invalid Email");
            }

            var user = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {                
                await cartService.CreateCartAsync(user);
                return RedirectToAction(nameof(Login));
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            var loginModel = new UserLoginFormModel();            
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
            if (user is null)
            {
                return BadRequest();
            }
            var result = await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(loginModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return Redirect("/Account/Login");
        }
    }
}
