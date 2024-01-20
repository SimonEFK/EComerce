namespace HardwareStore.App.Services.Cart
{
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;
    using Microsoft.EntityFrameworkCore;


    public class CartService : ICartService
    {
        private readonly ApplicationDbContext data;

        public CartService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task CreateCart(ApplicationUser applicationUser)
        {
            var userCart = await UserCartExsist(applicationUser);
            if (userCart != null)
            {
                throw new ArgumentException($"User with Id:{applicationUser.Id} Already has a cart");
            }

            var cart = new Cart()
            {
                ApplicationUser = applicationUser,

            };
            data.Carts.Add(cart);
            await data.SaveChangesAsync();

        }

        public async Task AddProductToCart(Cart cart, int productId)
        {
            var product = data.Products.FirstOrDefault(x => x.Id == productId);
            if (product == null)
            {
                throw new ArgumentNullException($"Product Id: {productId} is Invalid");
            }
            var productCartEntry = await data.CartProducts
                .FirstOrDefaultAsync(x => x.CartId == cart.Id && x.ProductId == productId);
            if (productCartEntry != null)
            {
                productCartEntry.Amount++;
            }
            else
            {
                productCartEntry = new CartProduct()
                {
                    CartId = cart.Id,
                    ProductId = productId
                };
                cart.Products.Add(productCartEntry);
            }
            await data.SaveChangesAsync();
        }

        public async Task<Cart> GetUserCart(ApplicationUser applicationUser)
        {
            var userCart = await UserCartExsist(applicationUser);
            if (userCart == null)
            {
                throw new ArgumentException($"User with Id:{applicationUser.Id} dosen't have cart");
            }
            return userCart;
        }

        private async Task<Cart?> UserCartExsist(ApplicationUser applicationUser)
        {
            return await data.Carts
                .FirstOrDefaultAsync(x => x.ApplicationUserId == applicationUser.Id);
        }
    }
}
