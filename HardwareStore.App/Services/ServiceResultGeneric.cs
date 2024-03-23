namespace HardwareStore.App.Services
{
    public class ServiceResultGeneric<T> : ServiceResult
    {
        public T Data { get; set; }
    }
}
