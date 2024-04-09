namespace HardwareStore.App.Controllers
{
    using AutoMapper;
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Models.Orders;
    using HardwareStore.App.Services.Orders;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class OrderController : Controller
    {
        private IMapper mapper;
        private UserManager<ApplicationUser> userManager;
        private IOrderProductService orderProductService;

        public OrderController(IMapper mapper, UserManager<ApplicationUser> userManager, IOrderProductService orderProductService)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.orderProductService = orderProductService;
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

            return Redirect("/Cart");
        }

        public async Task<IActionResult> UserOrders()
        {
            var user = await userManager.GetUserAsync(this.HttpContext.User);

            var userOrders = await orderProductService.GetUserOrdersAsync(user.Id);

            return View(userOrders.ToList());
        }
    }
}
