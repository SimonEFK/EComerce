namespace HardwareStore.App.Services
{
    public class ServiceResult
    {
        public bool Success { get; set; } =true;
        
        public ICollection<string> ErrorMessage { get; set; } = new List<string>();
    }
}
