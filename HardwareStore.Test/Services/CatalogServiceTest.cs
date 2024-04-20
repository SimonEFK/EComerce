namespace HardwareStore.Test.Services
{
    using AutoMapper;
    using HardwareStore.App;
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Models.Product;
    using HardwareStore.App.Services.Catalog;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CatalogServiceTest
    {

        [Fact]
        public async Task GetProductsByCategoryIdReturnsCorrectProducts()
        {
            var dbcontext = GetInMemoryDBContext();
            var mapper = GetMapper();
            await SeedProducts(dbcontext);
            var catalogService = new CatalogService(dbcontext, mapper);

            var products = await catalogService.GetProducts(null).ByCategory(1).ToList<ProductSimplifiedModel>();
            Assert.True(products.Count == 2);
            Assert.True(products.All(x => x.CategoryId == 1));

        }

        [Fact]
        public async Task GetProductsBySearchStringReturnsCorrectProducts()
        {
            var dbcontext = GetInMemoryDBContext();
            var mapper = GetMapper();
            await SeedProducts(dbcontext);
            var catalogService = new CatalogService(dbcontext, mapper);

            var products = await catalogService.GetProducts("razer").ToList<ProductSimplifiedModel>();
            Assert.True(products.Count == 2);
            Assert.True(products.All(x => x.Name.Contains("razer")));

        }

        [Fact]
        public async Task GetProductsByManufacturerReturnsCorrectProducts()
        {
            var dbcontext = GetInMemoryDBContext();
            var mapper = GetMapper();
            await SeedProducts(dbcontext);
            var catalogService = new CatalogService(dbcontext, mapper);

            var manufacturerIds = new HashSet<int>()
            {
              3
            };

            var products = await catalogService.GetProducts(null).ByManufacturer(manufacturerIds).ToList<ProductSimplifiedModel>();
            Assert.True(products.Count == 2);
            
        }

        [Fact]
        public async Task GetProductsByIdReturnsCorrectProduct()
        {
            var dbcontext = GetInMemoryDBContext();
            var mapper = GetMapper();
            await SeedProducts(dbcontext);
            var catalogService = new CatalogService(dbcontext, mapper);

            

            var product = await catalogService.GetProductById(1);
            Assert.True(product is not null);
            Assert.True(product.Id == 1);

        }

        [Fact]
        public async Task GetLatestProductsReturnsCorrectProducts()
        {
            var dbcontext = GetInMemoryDBContext();
            var mapper = GetMapper();
            await SeedProducts(dbcontext);
            var catalogService = new CatalogService(dbcontext, mapper);

            var products = await catalogService.GetLatestProductsAsync(4);
            Assert.True(products.Count == 4);            

        }


        private static ApplicationDbContext GetInMemoryDBContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            return dbContext;
        }

        public async Task SeedProducts(ApplicationDbContext dbContext)
        {
            var categories = new List<Category>
            {
              new Category
              {
                  Id = 1,
                  Name = "CPU"
              },
              new Category
              {
                  Id = 2,
                  Name = "Mouse"
              },
              new Category
              {
                  Id = 3,
                  Name = "Keyboard"
              }
            };
            var manufacturers = new List<Manufacturer>
            {
              new Manufacturer
              {
                  Id = 1,
                  Name= "AMD"
              },
              new Manufacturer
              {
                  Id = 2,
                  Name = "Razer"
              },
              new Manufacturer
              {
                  Id = 3,
                  Name = "Logitech"
              },
            };

            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    ManufacturerId = 1,
                    CategoryId = 1,
                    Name = "ryzen5",
                },
                new Product
                {
                    Id = 2,
                    ManufacturerId = 1,
                    CategoryId = 1,
                    Name = "ryzen4",
                },
                new Product
                {
                    Id = 3,
                    ManufacturerId = 2,
                    CategoryId = 2,
                    Name = "razer1",
                },
                new Product
                {
                    Id = 4,
                    ManufacturerId = 2,
                    CategoryId = 2,
                    Name = "razer2",
                },
                new Product
                {
                    Id = 5,
                    ManufacturerId = 3,
                    CategoryId = 3,
                    Name = "logitech1",
                },
                new Product
                {
                    Id = 6,
                    ManufacturerId = 3,
                    CategoryId = 3,
                    Name = "logitech2",
                }
            };
            var specifications = new List<Specification>
            {
                new Specification
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Core Count",
                    Values = new List<SpecificationValue>
                    {
                        new SpecificationValue
                        {
                            Id = 1,
                            SpecificationId = 1,
                            Value = "8"
                        },
                        new SpecificationValue
                        {
                            Id = 2,
                            SpecificationId = 1,
                            Value = "16"
                        },
                    }
                },
                new Specification
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "Socket",
                    Values = new List<SpecificationValue>
                    {
                        new SpecificationValue
                        {
                            Id = 3,
                            SpecificationId = 2,
                            Value = "AM4"

                        },
                        new SpecificationValue
                        {
                            Id = 4,
                            SpecificationId = 2,
                            Value = "AM5"
                        },
                    }
                },
                new Specification
                {
                    Id = 3,
                    CategoryId = 2,
                    Name = "Color",
                    Values = new List<SpecificationValue>
                    {
                        new SpecificationValue
                        {
                            Id= 5,
                            SpecificationId= 3,
                            Value = "Black"
                        },
                        new SpecificationValue
                        {
                            Id= 6,
                            SpecificationId= 3,
                            Value = "Green"
                        },
                    }

                },
                new Specification
                {
                    Id = 4,
                    CategoryId = 2,
                    Name = "Speed",
                    Values = new List<SpecificationValue>
                    {
                        new SpecificationValue
                        {
                            Id= 7,
                            SpecificationId= 4,
                            Value = "1600"
                        },
                        new SpecificationValue
                        {
                            Id= 8,
                            SpecificationId= 4,
                            Value = "2400"
                        },
                    }

                },
                new Specification
                {
                    Id = 5,
                    CategoryId = 3,
                    Name = "Type",
                    Values = new List<SpecificationValue>
                    {
                        new SpecificationValue
                        {
                            Id = 9,
                            SpecificationId = 5,
                            Value ="Mechanical",
                        },
                        new SpecificationValue
                        {
                            Id = 10,
                            SpecificationId = 5,
                            Value ="Standard",
                        }
                    }
                },
                new Specification
                {
                    Id = 6,
                    CategoryId = 3,
                    Name = "RGB",
                    Values = new List<SpecificationValue>
                    {
                        new SpecificationValue
                        {
                            Id= 11,
                            SpecificationId= 6,
                            Value= "Yes"
                        },
                        new SpecificationValue
                        {
                            Id= 12,
                            SpecificationId= 6,
                            Value= "No"
                        }
                    }
                }
            };


            await dbContext.Categories.AddRangeAsync(categories);
            await dbContext.Manufacturers.AddRangeAsync(manufacturers);
            await dbContext.Specifications.AddRangeAsync(specifications);
            await dbContext.AddRangeAsync(products);

            await dbContext.SaveChangesAsync();



        }

        private static IMapper GetMapper()
        {
            var mapper = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingProfile>();
            }).CreateMapper();
            return mapper;
        }
    }
}
