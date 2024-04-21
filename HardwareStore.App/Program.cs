namespace HardwareStore.App
{
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Extension;
    using HardwareStore.App.Services;
    using HardwareStore.App.Services.Cart;
    using HardwareStore.App.Services.Catalog;
    using HardwareStore.App.Services.Data;
    using HardwareStore.App.Services.Data.Category;
    using HardwareStore.App.Services.Data.Products;
    using HardwareStore.App.Services.Data.Products.Create;
    using HardwareStore.App.Services.Data.Products.Edit;
    using HardwareStore.App.Services.Data.Products.ProductSpecifications;
    using HardwareStore.App.Services.DownloadImage;
    using HardwareStore.App.Services.Orders;
    using HardwareStore.App.Services.PriceManager;
    using HardwareStore.App.Services.ProductDiscount;
    using HardwareStore.App.Services.ProductFiltering;
    using HardwareStore.App.Services.ProductReview;
    using HardwareStore.App.Services.Validation;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using PayPal.Api;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.SignIn.RequireConfirmedAccount = false;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
            });
            builder.Services.AddAntiforgery(options => options.HeaderName = "X-CSRF-TOKEN");
            builder.Services.AddControllersWithViews();
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddScoped<IProductDataService, ProductDataService>();
            builder.Services.AddScoped<IGenerateProductFilterOptionService, GenerateProductFilterOptionService>();
            builder.Services.AddSingleton<APIContext,APIContext>();
            builder.Services.AddSingleton<IPayPalService,PayPalService>();
            builder.Services.AddScoped<ICategoryDataService, CategoryDataService>();
            builder.Services.AddScoped<IManufacturerDataService, ManufacturerDataService>();
            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<ICatalogService, CatalogService>();
            builder.Services.AddScoped<IDownloadImageService, DownloadImageService>();
            builder.Services.AddScoped<IProductReviewService, ProductReviewService>();
            builder.Services.AddScoped<IValidatorService, ValidatorService>();
            builder.Services.AddScoped<IPriceManagerService, PriceManagerService>();
            builder.Services.AddScoped<IProductDiscountService, ProductDiscountService>();
            builder.Services.AddScoped<ICreateProductService, CreateProductService>();
            builder.Services.AddScoped<IEditProductService, EditProductService>();
            builder.Services.AddScoped<IProductSpecificationService, ProductSpecificationService>();
            builder.Services.AddScoped<IOrderProductService, OrderProductService>();
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.ApplyMigrations();
            app.SeedAdmin();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();



            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "catalog",
                pattern: "{controller=Catalog}/{action=Index}/{page=1}/{category?}");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();
            
            app.Run();
        }
    }
}