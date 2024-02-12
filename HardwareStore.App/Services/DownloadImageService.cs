namespace HardwareStore.App.Services
{
    public class DownloadImageService : IDownloadImageService
    {
        public async Task<string> DownloadImageAsync(string directoryPath, string fileName, Uri uri)
        {

            using var httpClient = new HttpClient();

            var uriWithoutQuery = uri.GetLeftPart(UriPartial.Path);

            var fileExtension = Path.GetExtension(uriWithoutQuery);


            var path = Path.Combine(directoryPath, $"{fileName}{fileExtension}");

            var imageBytes = await httpClient.GetByteArrayAsync(uri);

            await File.WriteAllBytesAsync(path, imageBytes);


            return $"{fileExtension}";
        }
    }
}
