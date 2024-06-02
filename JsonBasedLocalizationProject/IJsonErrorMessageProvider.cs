using JsonBasedLocalizationProject.Models;

namespace JsonBasedLocalizationProject;

public interface IJsonErrorMessageProvider
{
    Task<ErrorMessageResponse?> GetErrorMessage(string errorCode);
}