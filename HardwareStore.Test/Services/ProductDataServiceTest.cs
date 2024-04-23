namespace HardwareStore.Test.Services
{
    using AutoMapper;
    using HardwareStore.App;
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Models.Product;
    using HardwareStore.App.Services.Data.Products;
    using HardwareStore.App.Services.Data.Products.Create;
    using HardwareStore.App.Services.Data.Products.Edit;
    using HardwareStore.App.Services.Data.Products.ProductSpecifications;
    using HardwareStore.App.Services.Validation;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ProductDataServiceTest
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
            var productDataService = new ProductDataService(null, null, createProductService, null);

            var createProductDTO = new CreateProductDTO
            {
                Name = "Ryzen5",
                NameDetailed = "Ryzen5DetailedName",
                CategoryId = 1,
                ManufacturerId = 1,
                Specifications = new HashSet<int>
                {
                    2,3
                },
                ImageUrls = new HashSet<string>
                {
                    "https://www.dpnow.com/images/PhotoFixChallenge/DSC00092small.jpg",
                }

            };
            var result = await productDataService.CreateProductAsync<ProductSimplifiedModel>(createProductDTO);


            var product = dbContext.Products.Include(x => x.Images).Include(x => x.Specifications).FirstOrDefault();
            Assert.True(result.Success);
            Assert.True(product.Name == createProductDTO.Name);
            Assert.True(product.NameDetailed == createProductDTO.NameDetailed);
            Assert.True(product.Images.Any(x => x.Url == createProductDTO.ImageUrls.First()));
            Assert.True(product.ManufacturerId == createProductDTO.ManufacturerId);
            Assert.True(product.Specifications.Count == 2);


        }

        [Theory]
        [InlineData("productName", "productNameDetailed", 1, 1, 1, "invalidUrl")]
        [InlineData("productName", "productNameDetailed", 1, 234, 1, "https://www.dpnow.com/images/PhotoFixChallenge/DSC00092small.jpg")]
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
            var productDataService = new ProductDataService(null, null, createProductService, null);
            var specifications = new HashSet<int>
            {
                specification
            };
            var images = new HashSet<string>
            {
                image
            };
            var createProductDTO = new CreateProductDTO
            {
                Name = name,
                NameDetailed = nameDetailed,
                CategoryId = categoryId,
                ManufacturerId = manufacturerId,
                Specifications = specifications,
                ImageUrls = images

            };

            await Assert.ThrowsAnyAsync<Exception>(async () => await productDataService
                .CreateProductAsync<ProductSimplifiedModel>(createProductDTO));
        }

        [Fact]
        public async Task EditProductCorrectly()
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
                },
                new Manufacturer
                {
                    Id = 2,
                    Name = "Intel"
                }

            };

            var product = new Product
            {
                Id = 1,
                Name = "oldName",
                NameDetailed = "oldNameDetailed",
                CategoryId = 1,
                ManufacturerId = 1,
            };


            dbContext.Categories.AddRange(categories);
            dbContext.Manufacturers.AddRange(manufacturers);
            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            var productSpecificationService = new ProductSpecificationService(validatorService, dbContext);
            var editProductService = new EditProductService(dbContext, productSpecificationService, mapper, validatorService);
            var productDataService = new ProductDataService(null, null, null, editProductService);

            var editProductDTO = new EditProductDTO
            {
                Id = 1,
                Name = "newName",
                NameDetailed = "newNameDetailed",
                CategoryId = 2,
                ManufacturerId = 2,
            };
            var result = await productDataService.EditProductAsync<ProductSimplifiedModel>(editProductDTO);
            var dbProduct = dbContext.Products.FirstOrDefault();

            Assert.True(result.Success);
            Assert.True(dbProduct.Name == editProductDTO.Name);
            Assert.True(dbProduct.NameDetailed == editProductDTO.NameDetailed);
            Assert.True(dbProduct.CategoryId == editProductDTO.CategoryId);
            Assert.True(dbProduct.ManufacturerId == editProductDTO.ManufacturerId);

        }

        [Theory]
        [InlineData(1, 5)]
        [InlineData(5, 1)]
        public async Task EditProductThrowsExceptionIfInputIsInvalid(int categoryId, int manufacturerId)
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
                },
                new Manufacturer
                {
                    Id = 2,
                    Name = "Intel"
                }

            };

            var product = new Product
            {
                Id = 1,
                Name = "oldName",
                NameDetailed = "oldNameDetailed",
                CategoryId = 1,
                ManufacturerId = 1,
            };


            dbContext.Categories.AddRange(categories);
            dbContext.Manufacturers.AddRange(manufacturers);
            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            var productSpecificationService = new ProductSpecificationService(validatorService, dbContext);
            var editProductService = new EditProductService(dbContext, productSpecificationService, mapper, validatorService);
            var productDataService = new ProductDataService(null, null, null, editProductService);

            var editProductDTO = new EditProductDTO
            {
                Id = 1,
                Name = "newName",
                NameDetailed = "newNameDetailed",
                CategoryId = categoryId,
                ManufacturerId = manufacturerId,
            };

            await Assert.ThrowsAnyAsync<Exception>(async () => await productDataService
                .EditProductAsync<ProductSimplifiedModel>(editProductDTO));

        }

        [Fact]
        public async Task EditProductServiceAddsImageCorrectly()
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
                },
                new Manufacturer
                {
                    Id = 2,
                    Name = "Intel"
                }

            };

            var product = new Product
            {
                Id = 1,
                Name = "oldName",
                NameDetailed = "oldNameDetailed",
                CategoryId = 1,
                ManufacturerId = 1,
            };


            dbContext.Categories.AddRange(categories);
            dbContext.Manufacturers.AddRange(manufacturers);
            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            var productSpecificationService = new ProductSpecificationService(validatorService, dbContext);
            var editProductService = new EditProductService(dbContext, productSpecificationService, mapper, validatorService);
            var productDataService = new ProductDataService(null, null, null, editProductService);
            var imageUrl = "https://www.dpnow.com/images/PhotoFixChallenge/DSC00092small.jpg";

            var result = await productDataService.AddImageAsync(1, imageUrl);
            var productImages = dbContext.Products.FirstOrDefault(x => x.Id == 1).Images;
            Assert.True(result.Success);
            Assert.True(productImages.Any(x => x.Url == imageUrl));
        }

        [Fact]
        public async Task EditProductServiceThrowsExceptionIfImageIsInvalid()
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
                },
                new Manufacturer
                {
                    Id = 2,
                    Name = "Intel"
                }

            };

            var product = new Product
            {
                Id = 1,
                Name = "oldName",
                NameDetailed = "oldNameDetailed",
                CategoryId = 1,
                ManufacturerId = 1,
            };


            dbContext.Categories.AddRange(categories);
            dbContext.Manufacturers.AddRange(manufacturers);
            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            var productSpecificationService = new ProductSpecificationService(validatorService, dbContext);
            var editProductService = new EditProductService(dbContext, productSpecificationService, mapper, validatorService);
            var productDataService = new ProductDataService(null, null, null, editProductService);
            var imageUrl = "dasdsadsadsafwqdsadsadsadsadsadsa";

            await Assert.ThrowsAnyAsync<Exception>(async () => await productDataService.AddImageAsync(1, imageUrl));
        }

        [Fact]
        public async Task EditProductServiceFalseIfProductIsInvalid()
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
                },
                new Manufacturer
                {
                    Id = 2,
                    Name = "Intel"
                }

            };

            var product = new Product
            {
                Id = 321321,
                Name = "oldName",
                NameDetailed = "oldNameDetailed",
                CategoryId = 1,
                ManufacturerId = 1,
            };


            dbContext.Categories.AddRange(categories);
            dbContext.Manufacturers.AddRange(manufacturers);
            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            var productSpecificationService = new ProductSpecificationService(validatorService, dbContext);
            var editProductService = new EditProductService(dbContext, productSpecificationService, mapper, validatorService);
            var productDataService = new ProductDataService(null, null, null, editProductService);
            var imageUrl = "https://www.dpnow.com/images/PhotoFixChallenge/DSC00092small.jpg";

            var result = await productDataService.AddImageAsync(1, imageUrl);
            Assert.False(result.Success);
        }

        [Fact]
        public async Task EditProductServiceRemovesImageCorrectly()
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
                },
                new Manufacturer
                {
                    Id = 2,
                    Name = "Intel"
                }

            };

            var product = new Product
            {
                Id = 1,
                Name = "oldName",
                NameDetailed = "oldNameDetailed",
                CategoryId = 1,
                ManufacturerId = 1,
                Images = new List<Image>
                {
                    new Image
                    {
                        Id = "asddsa",
                        Url = "https://www.dpnow.com/images/PhotoFixChallenge/DSC00092small.jpg"

                    }
                 }
            };


            dbContext.Categories.AddRange(categories);
            dbContext.Manufacturers.AddRange(manufacturers);
            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            var productSpecificationService = new ProductSpecificationService(validatorService, dbContext);
            var editProductService = new EditProductService(dbContext, productSpecificationService, mapper, validatorService);
            var productDataService = new ProductDataService(null, null, null, editProductService);
            var imageId = "asddsa";



            var result = await productDataService.RemoveImageAsync(1, imageId);
            var productImages = dbContext.Products.FirstOrDefault(x => x.Id == 1).Images;
            Assert.True(result.Success);
            Assert.False(productImages.Any());
        }

        [Fact]
        public async Task EditProductServiceRemovesImageReturnsFalseIfProductIsInvalid()
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
                },
                new Manufacturer
                {
                    Id = 2,
                    Name = "Intel"
                }

            };

            var product = new Product
            {
                Id = 1,
                Name = "oldName",
                NameDetailed = "oldNameDetailed",
                CategoryId = 1,
                ManufacturerId = 1,
                Images = new List<Image>
                {
                    new Image
                    {
                        Id = "asddsa",
                        Url = "https://www.dpnow.com/images/PhotoFixChallenge/DSC00092small.jpg"

                    }
                 }
            };


            dbContext.Categories.AddRange(categories);
            dbContext.Manufacturers.AddRange(manufacturers);
            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            var productSpecificationService = new ProductSpecificationService(validatorService, dbContext);
            var editProductService = new EditProductService(dbContext, productSpecificationService, mapper, validatorService);
            var productDataService = new ProductDataService(null, null, null, editProductService);
            var imageId = "asddsa";



            var result = await productDataService.RemoveImageAsync(321321, imageId);

            Assert.False(result.Success);

        }

        [Fact]
        public async Task EditProductServiceAddsSpecificationValueCorrectly()
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
                },
                new Manufacturer
                {
                    Id = 2,
                    Name = "Intel"
                }

            };

            var product = new Product
            {
                Id = 1,
                Name = "oldName",
                NameDetailed = "oldNameDetailed",
                CategoryId = 1,
                ManufacturerId = 1,
            };


            dbContext.Categories.AddRange(categories);
            dbContext.Manufacturers.AddRange(manufacturers);
            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            var productSpecificationService = new ProductSpecificationService(validatorService, dbContext);
            var editProductService = new EditProductService(dbContext, productSpecificationService, mapper, validatorService);
            var productDataService = new ProductDataService(null, null, null, editProductService);
            var imageUrl = "https://www.dpnow.com/images/PhotoFixChallenge/DSC00092small.jpg";

            var result = await productDataService.AddSpecificationAsync(1, 3);
            var productSpecifications = dbContext.Products.Include(x => x.Specifications).FirstOrDefault(x => x.Id == 1).Specifications;

            Assert.True(result.Success);
            Assert.True(productSpecifications.Any());
            Assert.True(productSpecifications.Any(x => x.SpecificationValueId == 3));

        }

        [Theory]
        [InlineData(55, 1)]
        [InlineData(1, 55)]

        public async Task EditProductServiceAddsSpecificationValueReturnsFalseIfInputInvalid(int productId, int valueId)
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
                },
                new Manufacturer
                {
                    Id = 2,
                    Name = "Intel"
                }

            };

            var product = new Product
            {
                Id = 1,
                Name = "oldName",
                NameDetailed = "oldNameDetailed",
                CategoryId = 1,
                ManufacturerId = 1,
            };


            dbContext.Categories.AddRange(categories);
            dbContext.Manufacturers.AddRange(manufacturers);
            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            var productSpecificationService = new ProductSpecificationService(validatorService, dbContext);
            var editProductService = new EditProductService(dbContext, productSpecificationService, mapper, validatorService);
            var productDataService = new ProductDataService(null, null, null, editProductService);
            var imageUrl = "https://www.dpnow.com/images/PhotoFixChallenge/DSC00092small.jpg";

            var result = await productDataService.AddSpecificationAsync(productId, valueId);


            Assert.False(result.Success);

        }


        [Fact]
        public async Task EditProductServiceRemovesSpecificationValueCorrectly()
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
                },
                new Manufacturer
                {
                    Id = 2,
                    Name = "Intel"
                }

            };

            var product = new Product
            {
                Id = 1,
                Name = "oldName",
                NameDetailed = "oldNameDetailed",
                CategoryId = 1,
                ManufacturerId = 1,
                Images = new List<Image>
                {
                    new Image
                    {
                        Id = "asddsa",
                        Url = "https://www.dpnow.com/images/PhotoFixChallenge/DSC00092small.jpg"

                    }
                 },
            };


            dbContext.Categories.AddRange(categories);
            dbContext.Manufacturers.AddRange(manufacturers);
            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            var productSpecificationService = new ProductSpecificationService(validatorService, dbContext);
            var editProductService = new EditProductService(dbContext, productSpecificationService, mapper, validatorService);
            var productDataService = new ProductDataService(null, null, null, editProductService);
            var imageId = "asddsa";



            await productDataService.AddSpecificationAsync(1, 2);
            await productDataService.AddSpecificationAsync(1, 3);

            await productDataService.RemoveSpecificationAsync(1, 3);
            await productDataService.RemoveSpecificationAsync(1, 2);

            var productSpecifications = dbContext.Products.FirstOrDefault(x => x.Id == 1).Specifications;
            Assert.True(!productSpecifications.Any());

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
