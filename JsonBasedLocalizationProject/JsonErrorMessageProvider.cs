using JsonBasedLocalizationProject.Models;
using Newtonsoft.Json;

namespace JsonBasedLocalizationProject
{
    public class JsonErrorMessageProvider : IJsonErrorMessageProvider
    {
        public async Task<ErrorMessageResponse?> GetErrorMessage(string errorCode)
        {
            var filePath = $"Resources/{Thread.CurrentThread.CurrentCulture.Name}.json";
            var fullPath = Path.GetFullPath(filePath);
            if (File.Exists(fullPath))
            {
                var errorMessages = await GetErrorMessagesJson(fullPath);
                var errorMessage = errorMessages.Find(x => x.ErrorCode == errorCode);
                return errorMessage;
            }
            return default!;
        }
        private async Task<List<ErrorMessageResponse>> GetErrorMessagesJson(string filePath)
        {
            await using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var streamReader = new StreamReader(fileStream);
            var json = await streamReader.ReadToEndAsync();
            var errorMessages = JsonConvert.DeserializeObject<List<ErrorMessageResponse>>(json);
            return errorMessages ?? [];
        }
    }
}
