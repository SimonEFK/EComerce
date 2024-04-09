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

    public class OrderProductService : IOrderProductService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext dbContext;
        private IProductDiscountService productDiscountService;
        private IValidatorService validatorService;
        private IMapper mapper;


        public OrderProductService(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext, IProductDiscountService productDiscountService, IValidatorService validatorService, IMapper mapper)
        {
            _userManager = userManager;
            this.dbContext = dbContext;
            this.productDiscountService = productDiscountService;
            this.validatorService = validatorService;
            this.mapper = mapper;
        }

        public async Task<ServiceResult> CreateOrderAsync(ApplicationUser applicationUser, IEnumerable<CreateOrderItemDTO> orderItems)
        {
            var serviceResult = new ServiceResult();

            if (applicationUser is null)
            {
                serviceResult.Success = false;
                serviceResult.ErrorMessage = "Invalid User";
                return serviceResult;
            }


            var order = new Order
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

            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();

            await ClearUserCartAsync(applicationUser);

            return serviceResult;
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



    }
}
