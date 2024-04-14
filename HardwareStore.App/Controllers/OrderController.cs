namespace HardwareStore.App.Controllers
{
    using AutoMapper;
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Models.Orders;
    using HardwareStore.App.Services;
    using HardwareStore.App.Services.Orders;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualBasic;
    using PayPal.Api;

    public class OrderController : Controller
    {
        private IMapper mapper;
        private UserManager<ApplicationUser> userManager;
        private IOrderProductService orderProductService;
        private readonly IPayPalService payPalService;
        private APIContext payPalContext;

        public OrderController(IMapper mapper, UserManager<ApplicationUser> userManager, IOrderProductService orderProductService, IPayPalService payPalService)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.orderProductService = orderProductService;
            this.payPalService = payPalService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderInputModel orderInputModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await userManager.GetUserAsync(this.HttpContext.User);
            var orderItems = mapper.Map<List<CreateOrderItemDTO>>(orderInputModel.Items);

            var result = await orderProductService.CreateOrderAsync(user, orderItems);


            if (result.Success == false)
            {
                return BadRequest(result);
            }

            var orderId = result.Data;

            
            var payment = await orderProductService.CreatePayment(orderId);
            

            var url = payment.GetApprovalUrl();
            return Redirect(url);
        }

        public async Task<IActionResult> PaypalPayment(string payerId, string paymentId)
        {
            this.payPalContext = this.payPalService.GetAPIContext();
            var paymentExecution = new PaymentExecution { payer_id = payerId };
            var executedPayment = new Payment { id = paymentId }.Execute(this.payPalContext, paymentExecution);

            await orderProductService.UpdateOrderStatus(paymentId, executedPayment.state);

            return RedirectToAction(nameof(UserOrders));
        }

        public IActionResult PaypalFailPayment()
        {
            return BadRequest();
        }

        public async Task<IActionResult> UserOrders()
        {
            var user = await userManager.GetUserAsync(this.HttpContext.User);

            var userOrders = await orderProductService.GetUserOrdersAsync(user.Id);

            return View(userOrders.ToList());
        }
    }
}
