namespace HardwareStore.App.Data.SeedData
{
    using HardwareStore.App.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using System.Text.Json;


    public static class Seed
    {
     

        public static IEnumerable<T> Data<T>(string jsonFileName) where T : class
        {
            var jsonString = File.ReadAllText($"./Data/SeedData/json/{jsonFileName}");
            return JsonSerializer.Deserialize<IEnumerable<T>>(jsonString);
        }

    }
}
