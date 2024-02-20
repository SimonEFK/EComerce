namespace HardwareStore.App.Services.Cart
{
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Models.Product;
    using HardwareStore.App.Services.Models;
    using Microsoft.EntityFrameworkCore;


    public class CartService : ICartService
    {
        private readonly ApplicationDbContext data;
        private readonly DbContext dbContext;

        public CartService(ApplicationDbContext data)
        {
            this.data = data;

        }

        public async Task CreateCartAsync(ApplicationUser applicationUser)
        {
            var userCart = await UserCartExsistAsync(applicationUser);
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

        public async Task AddProductToCartAsync(ApplicationUser user, int productId)
        {
            var product = data.Products.FirstOrDefault(x => x.Id == productId);
            var userCart = await GetUserCartAsync(user);
            if (product == null)
            {
                throw new ArgumentNullException($"Product Id: {productId} is Invalid");
            }
            var productCartEntry = await data.CartProducts
                .FirstOrDefaultAsync(x => x.CartId == userCart.Id && x.ProductId == productId);
            if (productCartEntry != null)
            {
                productCartEntry.Amount++;
            }
            else
            {
                productCartEntry = new CartProduct()
                {
                    CartId = userCart.Id,
                    ProductId = productId
                };
                userCart.Products.Add(productCartEntry);
            }
            await data.SaveChangesAsync();
        }

        private async Task<Cart> GetUserCartAsync(ApplicationUser applicationUser)
        {
            var userCart = await UserCartExsistAsync(applicationUser);
            if (userCart == null)
            {
                throw new ArgumentException($"User with Id:{applicationUser.Id} dosen't have cart");
            }
            return userCart;
        }

        private async Task<Cart?> UserCartExsistAsync(ApplicationUser applicationUser)
        {
            return await data.Carts
                .FirstOrDefaultAsync(x => x.ApplicationUserId == applicationUser.Id);
        }

        public async Task<ICollection<CartProductModel>> GetUserCartProductsAsync(ApplicationUser applicationUser)
        {
            var cart = await data.Carts.FirstOrDefaultAsync(x => x.ApplicationUserId == applicationUser.Id);
            var cartProducts = await data.CartProducts.Where(x => x.CartId == cart.Id).Select(x => new CartProductModel
            {
                Amount = x.Amount,
                Id = x.ProductId,
                Name = x.Product.Name,
                CategoryId = x.Product.CategoryId,
                Image = x.Product.Images.FirstOrDefault().FilePath ?? x.Product.Images.FirstOrDefault().Url
            }).ToListAsync();


            return cartProducts;
        }
    }
}
