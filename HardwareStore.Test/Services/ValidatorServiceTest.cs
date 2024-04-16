namespace HardwareStore.Test.Services
{
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Services.ProductFiltering;
    using HardwareStore.App.Services.Validation;
    using Microsoft.EntityFrameworkCore;
    using Moq;

    public class ValidatorServiceTest
    {
       
        [Fact]
        public async Task IsProductValidReturnsTrueIfValidProductIdIsTheInput()
        {
            var serviceMock = new Mock<IGenerateProductFilterOptionService>();
            var dbContext = GetInMemoryDBContext();
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "product1",
                },
                new Product
                {
                    Id = 2,
                    Name = "product2",
                },

                new Product
                {
                    Id = 3,
                    Name = "product3",
                },
            };
            await dbContext.Products.AddRangeAsync(products);
            await dbContext.SaveChangesAsync();
            var validatorService = new ValidatorService(dbContext, serviceMock.Object);

            var result = await validatorService.IsProductValidAsync(1);

            Assert.True(result);
        }

        [Fact]
        public async Task IsProductValidReturnsFalseIfInvalidProductIdIsTheInput()
        {
            var serviceMock = new Mock<IGenerateProductFilterOptionService>();
            var dbContext = GetInMemoryDBContext();
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "product1",
                },
                new Product
                {
                    Id = 2,
                    Name = "product2",
                },

                new Product
                {
                    Id = 3,
                    Name = "product3",
                },
            };
            await dbContext.Products.AddRangeAsync(products);
            await dbContext.SaveChangesAsync();
            var validatorService = new ValidatorService(dbContext, serviceMock.Object);

            var result = await validatorService.IsProductValidAsync(9000);

            Assert.False(result);
        }

        [Fact]
        public async Task IsCategoryValidReturnsTrueIfValidCategoryIdIsTheInput()
        {
            var serviceMock = new Mock<IGenerateProductFilterOptionService>();
            var dbContext = GetInMemoryDBContext();
            var categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "cat1",
                },
                new Category
                {
                    Id = 2,
                    Name = "cat2",
                },

                new Category
                {
                    Id = 3,
                    Name = "cat3",
                },
            };
            await dbContext.Categories.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();
            var validatorService = new ValidatorService(dbContext, serviceMock.Object);

            var result = await validatorService.IsCategoryValidAsync(1);

            Assert.True(result);
        }

        [Fact]
        public async Task IsCategoryValidReturnsFalseIfInvalidCategoryIdIsTheInput()
        {
            var serviceMock = new Mock<IGenerateProductFilterOptionService>();
            var dbContext = GetInMemoryDBContext();
            var categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "cat1",
                },
                new Category
                {
                    Id = 2,
                    Name = "cat2",
                },

                new Category
                {
                    Id = 3,
                    Name = "cat3",
                },
            };
            await dbContext.Categories.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();
            var validatorService = new ValidatorService(dbContext, serviceMock.Object);

            var result = await validatorService.IsCategoryValidAsync(5555);

            Assert.False(result);
        }

        [Fact]
        public async Task IsManufacturerValidReturnsTrueIfValidManufacturerIdIsTheInput()
        {
            var serviceMock = new Mock<IGenerateProductFilterOptionService>();
            var dbContext = GetInMemoryDBContext();
            var manufacturers = new List<Manufacturer>
            {
                new Manufacturer
                {
                    Id = 1,
                    Name = "manufacturer1",
                },
                new Manufacturer
                {
                    Id = 2,
                    Name = "manufacturer2",
                },

                new Manufacturer
                {
                    Id = 3,
                    Name = "manufacturer3",
                },
            };
            await dbContext.Manufacturers.AddRangeAsync(manufacturers);
            await dbContext.SaveChangesAsync();
            var validatorService = new ValidatorService(dbContext, serviceMock.Object);

            var result = await validatorService.IsManufacturerValidAsync(1);

            Assert.True(result);
        }

        [Fact]
        public async Task IsManufacturerValidReturnsTrueIfValidManufacturerCollectionOfIdsIsTheInput()
        {
            var serviceMock = new Mock<IGenerateProductFilterOptionService>();
            var dbContext = GetInMemoryDBContext();
            var manufacturers = new List<Manufacturer>
            {
                new Manufacturer
                {
                    Id = 1,
                    Name = "manufacturer1",
                },
                new Manufacturer
                {
                    Id = 2,
                    Name = "manufacturer2",
                },

                new Manufacturer
                {
                    Id = 3,
                    Name = "manufacturer3",
                },
            };
            await dbContext.Manufacturers.AddRangeAsync(manufacturers);
            await dbContext.SaveChangesAsync();
            var validatorService = new ValidatorService(dbContext, serviceMock.Object);

            var validManufacturerIds = new HashSet<int>
            {
                1,
                2,
                3
            };

            var result = await validatorService.IsManufacturerValidAsync(validManufacturerIds);

            Assert.True(result);
        }

        [Fact]
        public async Task IsManufacturerValidReturnsFalseIfManufacturerCollectionContainsInvalidIdsIsTheInput()
        {
            var serviceMock = new Mock<IGenerateProductFilterOptionService>();
            var dbContext = GetInMemoryDBContext();
            var manufacturers = new List<Manufacturer>
            {
                new Manufacturer
                {
                    Id = 1,
                    Name = "manufacturer1",
                },
                new Manufacturer
                {
                    Id = 2,
                    Name = "manufacturer2",
                },

                new Manufacturer
                {
                    Id = 3,
                    Name = "manufacturer3",
                },
            };
            await dbContext.Manufacturers.AddRangeAsync(manufacturers);
            await dbContext.SaveChangesAsync();
            var validatorService = new ValidatorService(dbContext, serviceMock.Object);

            var validManufacturerIds = new HashSet<int>
            {
                1,
                234,
                3
            };

            var result = await validatorService.IsManufacturerValidAsync(validManufacturerIds);

            Assert.False(result);
        }

        [Fact]
        public async Task IsManufacturerValidReturnsFalseIfInvalidManufacturerIdIsTheInput()
        {
            var serviceMock = new Mock<IGenerateProductFilterOptionService>();
            var dbContext = GetInMemoryDBContext();
            var manufacturers = new List<Manufacturer>
            {
                new Manufacturer
                {
                    Id = 1,
                    Name = "manufacturer1",
                },
                new Manufacturer
                {
                    Id = 2,
                    Name = "manufacturer2",
                },

                new Manufacturer
                {
                    Id = 3,
                    Name = "manufacturer3",
                },
            };
            await dbContext.Manufacturers.AddRangeAsync(manufacturers);
            await dbContext.SaveChangesAsync();
            var validatorService = new ValidatorService(dbContext, serviceMock.Object);

            var result = await validatorService.IsManufacturerValidAsync(12345);

            Assert.False(result);
        }

        [Fact]
        public async Task IsSpecificationValidReturnsTrueIfValidSpecificationIdIsTheInput()
        {
            var serviceMock = new Mock<IGenerateProductFilterOptionService>();
            var dbContext = GetInMemoryDBContext();
            var specifications = new List<Specification>
            {
                new Specification
                {
                    Id = 1,
                    Name = "specification1",
                },
                new Specification
                {
                    Id = 2,
                    Name = "specification2",
                },

                new Specification
                {
                    Id = 3,
                    Name = "specification3",
                },
            };
            await dbContext.Specifications.AddRangeAsync(specifications);
            await dbContext.SaveChangesAsync();
            var validatorService = new ValidatorService(dbContext, serviceMock.Object);

            var result = await validatorService.IsSpecificationValidAsync(1);

            Assert.True(result);
        }

        [Fact]
        public async Task IsSpecificationValidReturnsFalseIfInvalidSpecificationIdIsTheInput()
        {
            var serviceMock = new Mock<IGenerateProductFilterOptionService>();
            var dbContext = GetInMemoryDBContext();
            var specifications = new List<Specification>
            {
                new Specification
                {
                    Id = 1,
                    Name = "specification1",
                },
                new Specification
                {
                    Id = 2,
                    Name = "specification2",
                },

                new Specification
                {
                    Id = 3,
                    Name = "specification3",
                },
            };
            await dbContext.Specifications.AddRangeAsync(specifications);
            await dbContext.SaveChangesAsync();
            var validatorService = new ValidatorService(dbContext, serviceMock.Object);

            var result = await validatorService.IsSpecificationValidAsync(1234);

            Assert.False(result);
        }

        [Fact]
        public async Task IsSpecificationValueValidReturnsTrueIfValidSpecificationValueIdIsTheInput()
        {
            var serviceMock = new Mock<IGenerateProductFilterOptionService>();
            var dbContext = GetInMemoryDBContext();
            var specificationValues = new List<SpecificationValue>
            {
                new SpecificationValue
                {
                    Id = 1,
                    Value = "value1",
                },
                new SpecificationValue
                {
                    Id = 2,
                    Value = "value2",
                },

                new SpecificationValue
                {
                    Id = 3,
                    Value = "value3",
                },
            };
            await dbContext.SpecificationValues.AddRangeAsync(specificationValues);
            await dbContext.SaveChangesAsync();
            var validatorService = new ValidatorService(dbContext, serviceMock.Object);

            var result = await validatorService.IsSpecificationValueValidAsync(1);

            Assert.True(result);
        }

        [Fact]
        public async Task IsSpecificationValueValidReturnsFalseIfInvalidSpecificationValueIdIsTheInput()
        {
            var serviceMock = new Mock<IGenerateProductFilterOptionService>();
            var dbContext = GetInMemoryDBContext();
            var specificationValues = new List<SpecificationValue>
            {
                new SpecificationValue
                {
                    Id = 1,
                    Value = "value1",
                },
                new SpecificationValue
                {
                    Id = 2,
                    Value = "value2",
                },

                new SpecificationValue
                {
                    Id = 3,
                    Value = "value3",
                },
            };
            await dbContext.SpecificationValues.AddRangeAsync(specificationValues);
            await dbContext.SaveChangesAsync();
            var validatorService = new ValidatorService(dbContext, serviceMock.Object);

            var result = await validatorService.IsSpecificationValueValidAsync(342);

            Assert.False(result);
        }

        [Fact]
        public async Task IsSpecificationValueValidReturnsTrueIfValidSpecificationValueCollectionOfIdsIsTheInput()
        {
            var serviceMock = new Mock<IGenerateProductFilterOptionService>();
            var dbContext = GetInMemoryDBContext();
            var specificationValues = new List<SpecificationValue>
            {
                new SpecificationValue
                {
                    Id = 1,
                    Value = "value1",
                },
                new SpecificationValue
                {
                    Id = 2,
                    Value = "value2",
                },

                new SpecificationValue
                {
                    Id = 3,
                    Value = "value3",
                },
            };
            await dbContext.SpecificationValues.AddRangeAsync(specificationValues);
            await dbContext.SaveChangesAsync();
            var validatorService = new ValidatorService(dbContext, serviceMock.Object);

            var validSpecificationValueIds = new HashSet<int>
            {
                1,
                2,
                3
            };

            var result = await validatorService.IsSpecificationValueValidAsync(validSpecificationValueIds);

            Assert.True(result);
        }

        [Fact]
        public async Task IsSpecificationValueValidReturnsFalseIfSpecificationValueCollectionContainsInvalidIdsIsTheInput()
        {
            var serviceMock = new Mock<IGenerateProductFilterOptionService>();
            var dbContext = GetInMemoryDBContext();
            var specificationValues = new List<SpecificationValue>
            {
                new SpecificationValue
                {
                    Id = 1,
                    Value = "value1",
                },
                new SpecificationValue
                {
                    Id = 2,
                    Value = "value2",
                },

                new SpecificationValue
                {
                    Id = 3,
                    Value = "value3",
                },
            };
            await dbContext.SpecificationValues.AddRangeAsync(specificationValues);
            await dbContext.SaveChangesAsync();
            var validatorService = new ValidatorService(dbContext, serviceMock.Object);

            var validSpecificationValueIds = new HashSet<int>
            {
                1,
                234,
                3
            };

            var result = await validatorService.IsSpecificationValueValidAsync(validSpecificationValueIds);

            Assert.False(result);
        }

        [Theory]
        [InlineData("newest")]
        [InlineData("oldest")]
        [InlineData("price asc")]
        public void IsSortOrderValueValidReturnsTrueIfSortOrderValueIsTheInput(string x)
        {

            var serviceMock = new Mock<IGenerateProductFilterOptionService>();
            var dbContext = GetInMemoryDBContext();

            var validSortOrders = new List<string>
            {
                "newest",
                "oldest",
                "price asc",
                "price desc",
                "rating asc",
                "rating desc"
            };
            serviceMock.Setup(x=>x.GenerateSortOrderOptions()).Returns(validSortOrders);
            
            var validatorService = new ValidatorService(dbContext, serviceMock.Object);

            var result = validatorService.IsSortOrderValueValid(x);

            Assert.True(result);
        }

        [Theory]
        [InlineData("thanos")]
        [InlineData("snaps")]        
        public void IsSortOrderValueValidReturnsFalseIfInvalidSortOrderValueIsTheInput(string x)
        {

            var serviceMock = new Mock<IGenerateProductFilterOptionService>();
            var dbContext = GetInMemoryDBContext();
            var validSortOrders = new List<string>
            {
                "newest",
                "oldest",
                "price asc",
                "price desc",
                "rating asc",
                "rating desc"
            };
            serviceMock.Setup(x => x.GenerateSortOrderOptions()).Returns(validSortOrders);
            var validatorService = new ValidatorService(dbContext, serviceMock.Object);
            
            var result = validatorService.IsSortOrderValueValid(x);

            Assert.False(result);
        }

        private static ApplicationDbContext GetInMemoryDBContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            return dbContext;
        }

    }

}
