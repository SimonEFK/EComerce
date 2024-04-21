namespace HardwareStore.Test.Services
{
    using AutoMapper;
    using HardwareStore.App;
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Models.Product;
    using HardwareStore.App.Services.Data.Products.Create;
    using HardwareStore.App.Services.Validation;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CreateProductServiceTest
    {
        [Fact]
        public async Task CreateProductCorrectly()
        {
            var dbContext = GetInMemoryDBContext();
            var mapper = GetMapper();
            var validatorService = new ValidatorService(dbContext, null);

            var categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Processor",
                    Specifications = new List<Specification>
                    {
                        new Specification
                        {
                            Id=1,
                            CategoryId = 1,
                            Name= "Core Count",

                            Values = new List<SpecificationValue>
                            {
                                new SpecificationValue
                                {
                                    Id = 1,
                                    SpecificationId = 1,
                                    Value = "4"
                                },
                                new SpecificationValue
                                {
                                    Id = 2,
                                    SpecificationId = 1,
                                    Value = "8"
                                }
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
                                }
                            }
                        }

                    }
                },
                new Category
                {
                    Id = 2,
                    Name = "Video Card"
                }
            };
            var manufacturers = new List<Manufacturer>
            {
                new Manufacturer
                {
                    Id = 1,
                    Name = "AMD"
                }

            };

            dbContext.Categories.AddRange(categories);
            dbContext.Manufacturers.AddRange(manufacturers);
            dbContext.SaveChanges();
            var createProductService = new CreateProductService(dbContext, validatorService, mapper);

            var name = "Ryzen5";
            var nameDetailed = "Ryzen5DetailedName";
            var categoryId = 1;
            var manufacturerId = 1;
            var specifications = new HashSet<int>
            {
                2,3
            };
            var images = new HashSet<string>
            {
                "https://www.dpnow.com/images/PhotoFixChallenge/DSC00092small.jpg",
            };
            var result = await createProductService
                .CreateProduct(name, categoryId, manufacturerId, nameDetailed)
                .AddSpecifications(specifications)
                .AddImages(images)
                .SaveChangesAsync<ProductSimplifiedModel>();

            var product = dbContext.Products.Include(x => x.Images).Include(x => x.Specifications).FirstOrDefault();
            Assert.True(result.Success);
            Assert.True(product.Name == "Ryzen5");
            Assert.True(product.NameDetailed == "Ryzen5DetailedName");
            Assert.True(product.Images.Any(x => x.Url == images.First()));
            Assert.True(product.ManufacturerId == manufacturerId);
            Assert.True(product.Specifications.Count == 2);


        }

        [Theory]
        [InlineData("productName", "productNameDetailed", 1, 1, 1, "invalidUrl")]
        [InlineData("productName","productNameDetailed",1,234,1, "https://www.dpnow.com/images/PhotoFixChallenge/DSC00092small.jpg")]
        [InlineData("productName", "productNameDetailed", 1, 1, 2555, "invalidUrl")]
        [InlineData("productName", "productNameDetailed", 1, 1, 1, "invalidUrl")]
        [InlineData("productName", "productNameDetailed", 54, 1, 1, "invalidUrl")]
        public async Task CreateProductThrowsExceptionIfInputInvalid(string name, string nameDetailed, int categoryId, int manufacturerId, int specification, string image)
        {
            var dbContext = GetInMemoryDBContext();
            var mapper = GetMapper();
            var validatorService = new ValidatorService(dbContext, null);

            var categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Processor",
                    Specifications = new List<Specification>
                    {
                        new Specification
                        {
                            Id=1,
                            CategoryId = 1,
                            Name= "Core Count",

                            Values = new List<SpecificationValue>
                            {
                                new SpecificationValue
                                {
                                    Id = 1,
                                    SpecificationId = 1,
                                    Value = "4"
                                },
                                new SpecificationValue
                                {
                                    Id = 2,
                                    SpecificationId = 1,
                                    Value = "8"
                                }
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
                                }
                            }
                        }

                    }
                },
                new Category
                {
                    Id = 2,
                    Name = "Video Card"
                }
            };
            var manufacturers = new List<Manufacturer>
            {
                new Manufacturer
                {
                    Id = 1,
                    Name = "AMD"
                }

            };

            dbContext.Categories.AddRange(categories);
            dbContext.Manufacturers.AddRange(manufacturers);
            dbContext.SaveChanges();
            var createProductService = new CreateProductService(dbContext, validatorService, mapper);


            var specifications = new HashSet<int>
            {
                specification
            };
            var images = new HashSet<string>
            {
                image
            };
            await Assert.ThrowsAnyAsync<Exception>(async()=> await createProductService
                .CreateProduct(name, categoryId, manufacturerId, nameDetailed)
                .AddSpecifications(specifications)
                .AddImages(images)
                .SaveChangesAsync<ProductSimplifiedModel>());
           
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
    }
}
