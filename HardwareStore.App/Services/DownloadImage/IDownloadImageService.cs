namespace HardwareStore.App.Services.DownloadImage
{
    using System;
    using System.Threading.Tasks;

    public interface IDownloadImageService
    {
        Task<string> DownloadImageAsync(string directoryPath, string fileName, Uri uri);
    }
}
