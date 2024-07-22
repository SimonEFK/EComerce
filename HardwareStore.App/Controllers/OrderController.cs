namespace HardwareStore.App.Controllers
{
    using AutoMapper;
    using HardwareStore.App.Extension;
    using HardwareStore.App.Models.Orders;
    using HardwareStore.App.Services;
    using HardwareStore.App.Services.Orders;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class OrderController : Controller
    {
        private IMapper mapper;        
        private IOrderProductService orderProductService;
        private readonly IPayPalService payPalService;

        public OrderController(IMapper mapper, IOrderProductService orderProductService, IPayPalService payPalService)
        {
            this.mapper = mapper;            
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
                return Redirect($"/Error/ErrorHandler");
            }

            var userId = this.HttpContext.User.Id();
            if (userId == null)
            {
                return Redirect($"/Error/ErrorHandler");
            }
            var orderItems = mapper.Map<List<CreateOrderItemDTO>>(orderInputModel.Items);
            var result = await orderProductService.CreateOrderAsync(userId, orderItems);

            if (result.Success == false)
            {
                return Redirect($"/Error/ErrorHandler?errorMessage={result.ErrorMessage}");
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
                return Redirect($"/Error/ErrorHandler");

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
                return Redirect($"/Error/ErrorHandler");
            }
            var userId = this.HttpContext.User.Id();

            await orderProductService.ClearUserCartAsync(userId);
            return RedirectToAction(nameof(UserOrders));
        }

        public IActionResult PaypalFailPayment()
        {

            return Redirect($"/Error/ErrorHandler");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UserOrders()
        {
            var userId = this.HttpContext.User.Id();

            if (userId == null)
            {
                return Redirect($"/Error/ErrorHandler");
            }

            var userOrders = await orderProductService.GetUserOrdersAsync(userId);

            return View(userOrders.ToList());
        }
    }
}
