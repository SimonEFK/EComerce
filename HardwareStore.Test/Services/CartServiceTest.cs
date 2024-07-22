namespace HardwareStore.Test.Services
{
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using HardwareStore.App;
    using HardwareStore.App.Services.Cart;
    using Microsoft.AspNetCore.Identity;
    using Moq;

    public class CartServiceTest
    {
        [Fact]
        public async Task CreateCartForUserCorrectly()
        {

            var dbContext = GetInMemoryDBContext();
            var mapper = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingProfile>();
            }).CreateMapper();

            var users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = "user1",

                },
                new ApplicationUser
                {
                    Id = "user2"
                },
            };
            await dbContext.Users.AddRangeAsync(users);
            await dbContext.SaveChangesAsync();

            var userManagerMock = UserManagerMock(users[0].Id, users[0]).Object;
            var cartService = new CartService(dbContext, mapper, userManagerMock);
            await cartService.CreateCartAsync(users[0].Id);

            var userCarts = dbContext.Carts.FirstOrDefaultAsync(x => x.ApplicationUserId == users[0].Id);
            Assert.NotNull(userCarts);

        }

        [Fact]
        public async Task CreateCartThrowsExceptionIfUserAlreadyHaveOne()
        {
            var dbContext = GetInMemoryDBContext();
            var mapper = GetMapper();

            var users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = "user1",

                },
                new ApplicationUser
                {
                    Id = "user2"
                },
            };
            await dbContext.Users.AddRangeAsync(users);
            await dbContext.SaveChangesAsync();


            var userManagerMock = UserManagerMock(users[0].Id, users[0]);

            var cartService = new CartService(dbContext, mapper, userManagerMock.Object);
            await cartService.CreateCartAsync(users[0].Id);
            await Assert.ThrowsAnyAsync<Exception>(async () => await cartService.CreateCartAsync(users[0].Id));

        }

        [Fact]
        public async Task AddProductToCartAddsProductToCartCorrectly()
        {
            var dbContext = GetInMemoryDBContext();
            var mapper = GetMapper();
            var user = new ApplicationUser
            {
                Id = "testUser",
            };
            var product = new Product
            {
                Id = 1,
                Name = "product1",
            };
            var userCart = new Cart
            {
                ApplicationUserId = user.Id,
            };
            await dbContext.Users.AddAsync(user);
            await dbContext.Products.AddAsync(product);
            await dbContext.Carts.AddAsync(userCart);
            await dbContext.SaveChangesAsync();

            var userManagerMock = UserManagerMock(user.Id, user);
            var cartService = new CartService(dbContext, mapper, userManagerMock.Object);

            await cartService.AddProductToCartAsync(user.Id, product.Id);

            Assert.True(user.Cart.Products.Count() == 1);
            Assert.True(user.Cart.Products.FirstOrDefault().Product.Id == product.Id);
        }

        [Fact]
        public async Task AddProductToCartSameProductIncreasesAmountCorrectly()
        {
            var dbContext = GetInMemoryDBContext();
            var mapper = GetMapper();
            var user = new ApplicationUser
            {
                Id = "testUser",
            };
            var product = new Product
            {
                Id = 1,
                Name = "product1",
            };
            var userCart = new Cart
            {
                ApplicationUserId = user.Id,
            };
            await dbContext.Users.AddAsync(user);
            await dbContext.Products.AddAsync(product);
            await dbContext.Carts.AddAsync(userCart);
            await dbContext.SaveChangesAsync();

            var userManagerMock = UserManagerMock(user.Id, user);

            var cartService = new CartService(dbContext, mapper, userManagerMock.Object);

            await cartService.AddProductToCartAsync(user.Id, product.Id);
            await cartService.AddProductToCartAsync(user.Id, product.Id);

            Assert.True(user.Cart.Products.Count() == 1);
            Assert.True(2 == user.Cart.Products.FirstOrDefault().Amount);
        }

        [Fact]
        public async Task AddProductToCartProductWithInvalidIdThrowsException()
        {
            var dbContext = GetInMemoryDBContext();
            var mapper = GetMapper();
            var user = new ApplicationUser
            {
                Id = "testUser",
            };
            var product = new Product
            {
                Id = 1,
                Name = "product1",
            };
            var userCart = new Cart
            {
                ApplicationUserId = user.Id,
            };
            await dbContext.Users.AddAsync(user);
            await dbContext.Products.AddAsync(product);
            await dbContext.Carts.AddAsync(userCart);
            await dbContext.SaveChangesAsync();

            var userManagerMock = UserManagerMock(user.Id, user);

            var cartService = new CartService(dbContext, mapper, userManagerMock.Object);

            await Assert.ThrowsAnyAsync<Exception>(async () => await cartService.AddProductToCartAsync(user.Id, 12334));

        }

        [Fact]
        public async Task RemoveItemFromCartCorrectly()
        {

            var dbContext = GetInMemoryDBContext();
            var mapper = GetMapper();
            var user = new ApplicationUser
            {
                Id = "testUser",
            };
            var product = new Product
            {
                Id = 1,
                Name = "product1",
            };
            var userCart = new Cart
            {
                ApplicationUserId = user.Id,
                Products = new List<CartProduct>
                {
                    new CartProduct
                    {
                        Amount =1 ,
                        ProductId = product.Id,
                    }
                }
            };
            await dbContext.Users.AddAsync(user);
            await dbContext.Products.AddAsync(product);
            await dbContext.Carts.AddAsync(userCart);
            await dbContext.SaveChangesAsync();

            var userManagerMock = UserManagerMock(user.Id, user);
            var cartService = new CartService(dbContext, mapper, userManagerMock.Object);

            await cartService.RemoveItem(user.Id, product.Id);

            Assert.False(user.Cart.Products.Any());
        }
        [Fact]
        public async Task RemoveItemThrowsExceptionIfProductIsInvalid()
        {

            var dbContext = GetInMemoryDBContext();
            var mapper = GetMapper();
            var user = new ApplicationUser
            {
                Id = "testUser",
            };
            var product = new Product
            {
                Id = 1,
                Name = "product1",
            };
            var userCart = new Cart
            {
                ApplicationUserId = user.Id,
                Products = new List<CartProduct>
                {
                    new CartProduct
                    {
                        Amount =1 ,
                        ProductId = product.Id,
                    }
                }
            };
            await dbContext.Users.AddAsync(user);
            await dbContext.Products.AddAsync(product);
            await dbContext.Carts.AddAsync(userCart);
            await dbContext.SaveChangesAsync();

            var userManagerMock = UserManagerMock(user.Id, user);

            var cartService = new CartService(dbContext, mapper, userManagerMock.Object);

            await Assert.ThrowsAnyAsync<Exception>(async () => await cartService.RemoveItem(user.Id, 555));

        }
        [Fact]
        public async Task RemoveItemThrowsExceptionIfUserCartDosentExsist()
        {

            var dbContext = GetInMemoryDBContext();
            var mapper = GetMapper();
            var user = new ApplicationUser
            {
                Id = "testUser",
            };
            var user2 = new ApplicationUser
            {
                Id = "testUser2",
            };
            var product = new Product
            {
                Id = 1,
                Name = "product1",
            };
            var userCart = new Cart
            {
                ApplicationUserId = user.Id,
                Products = new List<CartProduct>
                {
                    new CartProduct
                    {
                        Amount =1 ,
                        ProductId = product.Id,
                    }
                }
            };
            await dbContext.Users.AddAsync(user);
            await dbContext.Products.AddAsync(product);
            await dbContext.Carts.AddAsync(userCart);
            await dbContext.SaveChangesAsync();

            var userManagerMock = UserManagerMock(user2.Id, user2);

            var cartService = new CartService(dbContext, mapper, userManagerMock.Object);

            await Assert.ThrowsAnyAsync<Exception>(async () => await cartService.RemoveItem(user2.Id, 555));

        }

        [Fact]
        public async Task GetUserCartProductsReturnCorrectUserProducts()
        {
            var dbContext = GetInMemoryDBContext();
            var mapper = GetMapper();
            var user = new ApplicationUser
            {
                Id = "testUser",
            };
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "product1"
                },
                new Product
                {
                    Id = 2,
                    Name = "product2"
                },
                new Product
                {
                    Id = 3,
                    Name= "product2"
                }
            };
            var userCart = new Cart
            {
                ApplicationUserId = user.Id,
                Id = 5
            };
            var cartProducts = products.Select(x => new CartProduct
            {
                Amount = 1,
                CartId = userCart.Id,
                ProductId = x.Id
            });

            await dbContext.Users.AddAsync(user);
            await dbContext.Carts.AddAsync(userCart);
            await dbContext.Products.AddRangeAsync(products);
            await dbContext.CartProducts.AddRangeAsync(cartProducts);
            await dbContext.SaveChangesAsync();

            var userManagerMock = UserManagerMock(user.Id, user);
            var cartService = new CartService(dbContext, mapper, userManagerMock.Object);
            var userCartProducts = await cartService.GetUserCartProductsAsync(user.Id);

            Assert.True(userCartProducts.Count == 3);

        }



        private static ApplicationDbContext GetInMemoryDBContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            return dbContext;
        }

        private static IMapper GetMapper()
        {
            var mapper = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingProfile>();
            }).CreateMapper();
            return mapper;
        }

        private static Mock<UserManager<ApplicationUser>> UserManagerMock(string userId, ApplicationUser user)
        {
            var userManagerMock = new Mock<UserManager<ApplicationUser>>(
                    Mock.Of<IUserStore<ApplicationUser>>(),
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null);
            userManagerMock.Setup(u => u.FindByIdAsync(userId)).ReturnsAsync(user);

            return userManagerMock;

        }
    }
}
