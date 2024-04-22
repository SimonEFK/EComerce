namespace HardwareStore.App.Controllers
{
    using AutoMapper;
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Models.Orders;
    using HardwareStore.App.Services;
    using HardwareStore.App.Services.Orders;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using PayPal.Api;

    public class OrderController : Controller
    {
        private IMapper mapper;
        private UserManager<ApplicationUser> userManager;
        private IOrderProductService orderProductService;
        private readonly IPayPalService payPalService;

        public OrderController(IMapper mapper, UserManager<ApplicationUser> userManager, IOrderProductService orderProductService, IPayPalService payPalService)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.orderProductService = orderProductService;
            this.payPalService = payPalService;
        }

        [Authorize]
        public IActionResult Index()
        {
            return RedirectToAction(nameof(UserOrders));
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrder(OrderInputModel orderInputModel)
        {

            if (!ModelState.IsValid)
            {
                return Redirect($"/Error/BadRequest");
            }

            var user = await userManager.GetUserAsync(this.HttpContext.User);
            if (user == null)
            {
                return Redirect($"/Error/BadRequest");
            }
            var orderItems = mapper.Map<List<CreateOrderItemDTO>>(orderInputModel.Items);
            var result = await orderProductService.CreateOrderAsync(user, orderItems);

            if (result.Success == false)
            {
                return Redirect($"/Error/BadRequest?errorMessage={result.ErrorMessage}");
            }
            var orderId = result.Data;

            try
            {
                var payment = await orderProductService.CreatePayment(orderId);
                var url = payment.GetApprovalUrl();
                return Redirect(url);
            }
            catch (Exception ex)
            {
                return Redirect($"/Error/BadRequest");

            }
        }

        public async Task<IActionResult> PaypalPayment(string payerId, string paymentId)
        {

            try
            {
                await orderProductService.ExecutePayment(payerId, paymentId);
            }
            catch (Exception)
            {
                return Redirect($"/Error/BadRequest");
            }
            var user = await userManager.GetUserAsync(this.HttpContext.User);
            await orderProductService.ClearUserCartAsync(user);
            return RedirectToAction(nameof(UserOrders));
        }

        public IActionResult PaypalFailPayment()
        {

            return Redirect($"/Error/BadRequest");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UserOrders()
        {
            var user = await userManager.GetUserAsync(this.HttpContext.User);

            if (user == null)
            {
                return Redirect($"/Error/BadRequest");
            }

            var userOrders = await orderProductService.GetUserOrdersAsync(user.Id);

            return View(userOrders.ToList());
        }
    }
}
