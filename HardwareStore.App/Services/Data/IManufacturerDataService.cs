namespace HardwareStore.App.Services.Data
{
    using System.Collections.Generic;

    public interface IManufacturerDataService
    {
        Task<ICollection<(string Name, int Id)>> GetManufacturersAsTupleCollectionAsync();
    }
}
