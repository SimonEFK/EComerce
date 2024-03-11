namespace HardwareStore.App.Services.Validation
{
    using System.Threading.Tasks;

    public interface IValidatorService
    {
        Task<bool> IsProductValid(int productId);
    }
}
