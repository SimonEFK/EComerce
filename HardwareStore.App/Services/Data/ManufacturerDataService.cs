namespace HardwareStore.App.Services.Data
{
    using HardwareStore.App.Data;
    using Microsoft.EntityFrameworkCore;

    public class ManufacturerDataService : IManufacturerDataService
    {
        private readonly ApplicationDbContext dbContext;

        public ManufacturerDataService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<(string Name, int Id)>> GetManufacturersAsTupleCollectionAsync()
        {

            var query = await dbContext.Manufacturers.Select(x => new
            {
                Name = x.Name,
                Id = x.Id,
            }).ToListAsync();
            var manufacturerResult = new List<(string Name, int Id)>();

            foreach (var manufacturer in query)
            {
                manufacturerResult.Add((Name: manufacturer.Name, Id: manufacturer.Id));
            }

            return manufacturerResult;
        }
    }
}
