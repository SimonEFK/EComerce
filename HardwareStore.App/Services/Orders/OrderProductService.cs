namespace HardwareStore.App.Services.Orders
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;    
    using HardwareStore.App.Services.ProductDiscount;
    using HardwareStore.App.Services.Validation;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using PayPal.Api;
    

    public class OrderProductService : IOrderProductService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext dbContext;
        private IProductDiscountService productDiscountService;
        private IValidatorService validatorService;
        private IMapper mapper;
        private readonly IPayPalService payPalService;
        private APIContext apiContext;


        public OrderProductService(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext, IProductDiscountService productDiscountService, IValidatorService validatorService, IMapper mapper, IPayPalService payPalService)
        {
            _userManager = userManager;
            this.dbContext = dbContext;
            this.productDiscountService = productDiscountService;
            this.validatorService = validatorService;
            this.mapper = mapper;
            this.payPalService = payPalService;
        }

        public async Task<ServiceResultGeneric<string?>> CreateOrderAsync(ApplicationUser applicationUser, IEnumerable<CreateOrderItemDTO> orderItems)
        {
            var serviceResult = new ServiceResultGeneric<string?>();
            serviceResult.Data = null;

            if (applicationUser is null)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage = "Invalid User";
                return serviceResult;
            }


            var order = new HardwareStore.App.Data.Models.Order
            {
                ApplicationUserId = applicationUser.Id,
            };
            var orderProducts = new List<OrderProduct>();

            foreach (var orderItem in orderItems)
            {
                var isValid = await validatorService.IsProductValidAsync(orderItem.ProductId);

                if (!isValid)
                {
                    continue;
                }
                orderProducts.Add(new OrderProduct
                {
                    ProductId = orderItem.ProductId,
                    Amount = orderItem.Amount,
                });

            }

            orderProducts = OrderProductsSum(orderProducts).ToList();
            order.OrderProducts = orderProducts;
            order.OrderSum = orderProducts.Sum(x => x.TotalPrice);
            order.Status = "created";
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();

            await ClearUserCartAsync(applicationUser);
            serviceResult.Data = order.Id;
            return serviceResult;
        }


        public async Task<Payment> CreatePayment(string orderId)
        {
            this.apiContext = payPalService.GetAPIContext();
            var order = await dbContext.Orders.Where(x => x.Id == orderId).Include(x => x.OrderProducts).ThenInclude(x => x.Product).FirstOrDefaultAsync();

            var items = new List<Item>();

            foreach (var product in order.OrderProducts)
            {
                var item = new Item
                {
                    name = product.Product.Name,
                    currency = "USD",
                    price = product.Product.Price.ToString(),
                    quantity = product.Amount.ToString(),
                    sku = "sku"
                };
                items.Add(item);
            }


            var itemList = new ItemList();
            itemList.items = items;

            var payment = new Payment()
            {
                intent = "sale",
                payer = new Payer() { payment_method = "paypal" },
                transactions = new List<Transaction>()
                    {
                        new Transaction()
                        {
                            description = "Transaction description.",
                            invoice_number = order.Id,
                            amount = new Amount()
                            {
                                currency = "USD",
                                total = order.OrderSum.ToString()
                            },
                            item_list = itemList
                        }
                    },
                redirect_urls = new RedirectUrls()
                {
                    return_url = "https://localhost:7082/Order/PaypalPayment",
                    cancel_url = "https://localhost:7082/Order/PaypalPayment",
                }
            };

            var result = payment.Create(this.apiContext);

            order.Status = result.state;
            order.PaymentId = result.id;

            await dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<IEnumerable<OrderInfoDTO>> GetOrdersAsync()
        {
            var orders = await dbContext.Orders.ProjectTo<OrderInfoDTO>(mapper.ConfigurationProvider).ToListAsync();



            return orders;
        }

        public async Task<IEnumerable<OrderInfoDTO>> GetUserOrdersAsync(string userId)
        {
            var orders = await dbContext.Orders.Where(x => x.ApplicationUserId == userId).ProjectTo<OrderInfoDTO>(mapper.ConfigurationProvider).ToListAsync();

            return orders;
        }

        private IEnumerable<OrderProduct> OrderProductsSum(IEnumerable<OrderProduct> orderProducts)
        {

            foreach (var orderProduct in orderProducts)
            {
                var originPrice = productDiscountService.GetProductPrice(orderProduct.ProductId).Price;

                orderProduct.OriginalPrice = originPrice;

                orderProduct.TotalPrice = (originPrice * orderProduct.Amount);

            }
            return orderProducts;
        }

        private async Task ClearUserCartAsync(ApplicationUser applicationUser)
        {
            var userCart = await dbContext.Carts
                .Include(x => x.Products)
                .FirstOrDefaultAsync(c => c.ApplicationUserId == applicationUser.Id);

            userCart.Products.Clear();

            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateOrderStatus(string paymentId, string newStatus)
        {
            var order = await dbContext.Orders.FirstOrDefaultAsync(x=> x.PaymentId == paymentId);
            order.Status = newStatus;
            await dbContext.SaveChangesAsync();
        }

    }
}
