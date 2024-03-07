namespace HardwareStore.App.Services
{
    using System.Threading.Tasks;

    public interface IValidatorService
    {
        Task<bool> IsProductValid(int productId);
    }
}
