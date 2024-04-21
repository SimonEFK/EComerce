namespace HardwareStore.Test.Services
{
    using AutoMapper;
    using HardwareStore.App;
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Services.Data.Category;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    public class CategoryDataServiceTest
    {

        [Fact]
        public async Task CreateCategoryCreatesCategoryCorrectly()
        {
            var dbContext = GetInMemoryDBContext();
            var mapper = GetMapper();

            var categoryService = new CategoryDataService(mapper, dbContext, null);

            var result = await categoryService.CreateCategoryAsync("Processor", "randomUrl");
            Assert.True(result.Success == true);
            Assert.True(dbContext.Categories.Any(x => x.Name == "Processor"));
        }
        [Fact]
        public async Task CreateCategoryReturnsFalseIfCategoryAlreadyExsist()
        {
            var dbContext = GetInMemoryDBContext();
            var mapper = GetMapper();

            var categoryService = new CategoryDataService(mapper, dbContext, null);

            await categoryService.CreateCategoryAsync("Processor", "randomUrl");
            var result = await categoryService.CreateCategoryAsync("Processor", "randomUrl");
            Assert.True(result.Success == false);
        }
        [Theory]
        [InlineData(null, "randomUrl")]
        [InlineData("processorprocessorprocessorprocessorprocessorprocessorprocessorprocessorprocessorprocessorprocessorprocessorprocessorprocessorprocessorprocessorprocessorprocessorprocessorprocessorprocessorprocessor", "randomUrl")]
        public async Task CreateCategoryReturnsFalseIfCategoryParametarsAreInvalid(string name, string url)
        {
            var dbContext = GetInMemoryDBContext();
            var mapper = GetMapper();

            var categoryService = new CategoryDataService(mapper, dbContext, null);
            await Assert.ThrowsAnyAsync<Exception>(async () => await categoryService.CreateCategoryAsync(name, url));

        }

        [Fact]
        public async Task EditCategoryEditsCategoryCorrectly()
        {
            var dbContext = GetInMemoryDBContext();
            var mapper = GetMapper();

            var categories = new List<Category>
            {
                new Category
                {
                    Id= 1,
                    Name= "Processor"
                },
                new Category
                {
                    Id= 2,
                    Name= "Video Card"
                },
            };
            await dbContext.Categories.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();

            var categoryService = new CategoryDataService(mapper, dbContext, null);


            var result = await categoryService.EditCategoryAsync(1, "CPU", "newImageUrl");
            var editedCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == 1);

            Assert.True(result.Success);
            Assert.True(editedCategory.Name == "CPU");
            Assert.True(editedCategory.Url == "newImageUrl");
        }

        [Fact]
        public async Task EditCategoryReturnsFalseIfCategoryAlreadyExsist()
        {
            var dbContext = GetInMemoryDBContext();
            var mapper = GetMapper();

            var categories = new List<Category>
            {
                new Category
                {
                    Id= 1,
                    Name= "Processor"
                },
                new Category
                {
                    Id= 2,
                    Name= "Video Card"
                },
            };
            await dbContext.Categories.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();

            var categoryService = new CategoryDataService(mapper, dbContext, null);


            var result = await categoryService.EditCategoryAsync(1, "Video Card", "newImageUrl");
            var editedCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == 1);

            Assert.False(result.Success);
        }

        [Fact]
        public async Task EditCategoryReturnsFalseIfCategoryDosentExsist()
        {
            var dbContext = GetInMemoryDBContext();
            var mapper = GetMapper();

            var categories = new List<Category>
            {
                new Category
                {
                    Id= 1,
                    Name= "Processor"
                },
                new Category
                {
                    Id= 2,
                    Name= "Video Card"
                },
            };
            await dbContext.Categories.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();

            var categoryService = new CategoryDataService(mapper, dbContext, null);


            var result = await categoryService.EditCategoryAsync(5, "Video Card", "newImageUrl");
            var editedCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == 1);

            Assert.False(result.Success);
        }

        [Fact]
        public async Task CreateSpecificationCreatesCorrectly()
        {
            var dbContext = GetInMemoryDBContext();
            var mapper = GetMapper();

            var categories = new List<Category>
            {
                new Category
                {
                    Id= 1,
                    Name= "Processor"
                },
                new Category
                {
                    Id= 2,
                    Name= "Video Card"
                },
            };
            await dbContext.Categories.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();

            var categoryService = new CategoryDataService(mapper, dbContext, null);

            await categoryService.CreateSpecificationAsync(1, "Core Count");
            var categorySpecifications = dbContext.Categories.Include(x => x.Specifications).FirstOrDefault(x => x.Id == 1).Specifications;
            Assert.True(categorySpecifications.Any(x => x.Name == "Core Count"));
        }

        [Fact]
        public async Task CreateSpecificationReturnsFalseIfCategoryDosentExsist()
        {
            var dbContext = GetInMemoryDBContext();
            var mapper = GetMapper();

            var categories = new List<Category>
            {
                new Category
                {
                    Id= 1,
                    Name= "Processor"
                },
                new Category
                {
                    Id= 2,
                    Name= "Video Card"
                },
            };
            await dbContext.Categories.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();

            var categoryService = new CategoryDataService(mapper, dbContext, null);

            var result = await categoryService.CreateSpecificationAsync(5, "Core Count");

            Assert.False(result.Success);
        }

        [Fact]
        public async Task CreateSpecificationReturnsFalseIfSpecificationAlreadyExsist()
        {
            var dbContext = GetInMemoryDBContext();
            var mapper = GetMapper();

            var categories = new List<Category>
            {
                new Category
                {
                    Id= 1,
                    Name= "Processor"
                },
                new Category
                {
                    Id= 2,
                    Name= "Video Card"
                },
            };
            await dbContext.Categories.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();

            var categoryService = new CategoryDataService(mapper, dbContext, null);

            await categoryService.CreateSpecificationAsync(1, "Core Count");
            var result = await categoryService.CreateSpecificationAsync(1, "Core Count");

            Assert.False(result.Success);
        }

        [Fact]
        public async Task EditSpecificationCorrectly()
        {
            var dbContext = GetInMemoryDBContext();
            var mapper = GetMapper();

            var categories = new List<Category>
            {
                new Category
                {
                    Id= 1,
                    Name= "Processor",
                    Specifications = new List<Specification>
                    {
                        new Specification
                        {
                            Id= 1,
                            Name = "Core Count"
                        },
                        new Specification
                        {
                            Id= 2,
                            Name = "Socket"
                        },
                    }
                },
                new Category
                {
                    Id= 2,
                    Name= "Video Card"
                },
            };
            await dbContext.Categories.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();

            var categoryService = new CategoryDataService(mapper, dbContext, null);

            var result = await categoryService.EditSpecificationAsync(1, 1, "Count", true, true);
            var specification = dbContext.Specifications.FirstOrDefault(x => x.Id == 1);
            Assert.True(result.Success);
            Assert.True(specification.Name == "Count");
            Assert.True(specification.Filter == true);
            Assert.True(specification.InfoLevel == "Essential");
        }

        [Fact]
        public async Task EditSpecificationReturnsFalseIfSpecificationAlreadyExsist()
        {
            var dbContext = GetInMemoryDBContext();
            var mapper = GetMapper();

            var categories = new List<Category>
            {
                new Category
                {
                    Id= 1,
                    Name= "Processor",
                    Specifications = new List<Specification>
                    {
                        new Specification
                        {
                            Id= 1,
                            Name = "Core Count"
                        },
                        new Specification
                        {
                            Id= 2,
                            Name = "Socket"
                        },
                    }
                },
                new Category
                {
                    Id= 2,
                    Name= "Video Card"
                },
            };
            await dbContext.Categories.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();

            var categoryService = new CategoryDataService(mapper, dbContext, null);

            var result = await categoryService.EditSpecificationAsync(1, 1, "Socket", true, true);

            Assert.False(result.Success);
        }

        [Fact]
        public async Task EditSpecificationReturnsFalseIfCategoryIsInvalid()
        {
            var dbContext = GetInMemoryDBContext();
            var mapper = GetMapper();

            var categories = new List<Category>
            {
                new Category
                {
                    Id= 1,
                    Name= "Processor",
                    Specifications = new List<Specification>
                    {
                        new Specification
                        {
                            Id= 1,
                            Name = "Core Count"
                        },
                        new Specification
                        {
                            Id= 2,
                            Name = "Socket"
                        },
                    }
                },
                new Category
                {
                    Id= 2,
                    Name= "Video Card"
                },
            };
            await dbContext.Categories.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();

            var categoryService = new CategoryDataService(mapper, dbContext, null);

            var result = await categoryService.EditSpecificationAsync(1234, 1, "Count", true, true);

            Assert.False(result.Success);
        }

        [Fact]
        public async Task EditSpecificationReturnsFalseIfSpecificationIsInvalid()
        {
            var dbContext = GetInMemoryDBContext();
            var mapper = GetMapper();

            var categories = new List<Category>
            {
                new Category
                {
                    Id= 1,
                    Name= "Processor",
                    Specifications = new List<Specification>
                    {
                        new Specification
                        {
                            Id= 1,
                            Name = "Core Count"
                        },
                        new Specification
                        {
                            Id= 2,
                            Name = "Socket"
                        },
                    }
                },
                new Category
                {
                    Id= 2,
                    Name= "Video Card"
                },
            };
            await dbContext.Categories.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();

            var categoryService = new CategoryDataService(mapper, dbContext, null);

            var result = await categoryService.EditSpecificationAsync(1, 55, "Count", true, true);

            Assert.False(result.Success);
        }

        [Fact]
        public async Task CreateSpecificationValueCreatesCorrectly()
        {
            var dbContext = GetInMemoryDBContext();
            var mapper = GetMapper();

            var categories = new List<Category>
            {
                new Category
                {
                    Id= 1,
                    Name= "Processor",
                    Specifications = new List<Specification>
                    {
                        new Specification
                        {
                            Id= 1,
                            Name = "Core Count",
                            Values = new List<SpecificationValue>
                            {
                                new SpecificationValue
                                {
                                    Id= 1,
                                    Value = "8"
                                },
                                new SpecificationValue
                                {
                                    Id = 2,
                                    Value = "16"
                                },
                            }
                        },
                    }

                },
                new Category
                {
                    Id= 2,
                    Name= "Video Card"
                },
            };
            await dbContext.Categories.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();

            var categoryService = new CategoryDataService(mapper, dbContext, null);

            var result = await categoryService.CreateSpecificationValueAsync(1, 1, "4", null);
            var specificationValues = dbContext.Specifications.Include(x => x.Values).Where(x => x.CategoryId == 1 && x.Id==1).FirstOrDefault().Values;
            Assert.True(result.Success);
            Assert.True(specificationValues.Any(x => x.Value == "4"));

        }

        [Fact]
        public async Task CreateSpecificationValueReturnsFalseIfCategoryIsInvalid()
        {
            var dbContext = GetInMemoryDBContext();
            var mapper = GetMapper();

            var categories = new List<Category>
            {
                new Category
                {
                    Id= 1,
                    Name= "Processor",
                    Specifications = new List<Specification>
                    {
                        new Specification
                        {
                            Id= 1,
                            Name = "Core Count",
                            Values = new List<SpecificationValue>
                            {
                                new SpecificationValue
                                {
                                    Id= 1,
                                    Value = "8"
                                },
                                new SpecificationValue
                                {
                                    Id = 2,
                                    Value = "16"
                                },
                            }
                        },
                    }

                },
                new Category
                {
                    Id= 2,
                    Name= "Video Card"
                },
            };
            await dbContext.Categories.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();

            var categoryService = new CategoryDataService(mapper, dbContext, null);

            var result = await categoryService.CreateSpecificationValueAsync(123, 1, "4", null);
            
            Assert.False(result.Success);
            

        }

        [Fact]
        public async Task CreateSpecificationValueReturnsFalseIfSpecificationIsInvalid()
        {
            var dbContext = GetInMemoryDBContext();
            var mapper = GetMapper();

            var categories = new List<Category>
            {
                new Category
                {
                    Id= 1,
                    Name= "Processor",
                    Specifications = new List<Specification>
                    {
                        new Specification
                        {
                            Id= 1,
                            Name = "Core Count",
                            Values = new List<SpecificationValue>
                            {
                                new SpecificationValue
                                {
                                    Id= 1,
                                    Value = "8"
                                },
                                new SpecificationValue
                                {
                                    Id = 2,
                                    Value = "16"
                                },
                            }
                        },
                    }

                },
                new Category
                {
                    Id= 2,
                    Name= "Video Card"
                },
            };
            await dbContext.Categories.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();

            var categoryService = new CategoryDataService(mapper, dbContext, null);

            var result = await categoryService.CreateSpecificationValueAsync(1, 1123, "4", null);

            Assert.False(result.Success);


        }

        [Fact]
        public async Task CreateSpecificationValueReturnsFalseIfSpecificationValueAlreadyExsist()
        {
            var dbContext = GetInMemoryDBContext();
            var mapper = GetMapper();

            var categories = new List<Category>
            {
                new Category
                {
                    Id= 1,
                    Name= "Processor",
                    Specifications = new List<Specification>
                    {
                        new Specification
                        {
                            Id= 1,
                            Name = "Core Count",
                            Values = new List<SpecificationValue>
                            {
                                new SpecificationValue
                                {
                                    Id= 1,
                                    Value = "8"
                                },
                                new SpecificationValue
                                {
                                    Id = 2,
                                    Value = "16"
                                },
                            }
                        },
                    }

                },
                new Category
                {
                    Id= 2,
                    Name= "Video Card"
                },
            };
            await dbContext.Categories.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();

            var categoryService = new CategoryDataService(mapper, dbContext, null);

            var result = await categoryService.CreateSpecificationValueAsync(1, 1, "16", null);

            Assert.False(result.Success);

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
