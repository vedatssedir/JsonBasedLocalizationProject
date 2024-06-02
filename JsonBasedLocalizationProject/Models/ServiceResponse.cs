namespace JsonBasedLocalizationProject.Models
{
    public class ServiceResponse<T> where T : class
    {
        public bool IsSuccessful { get; set; }
        public T Data { get; set; }
        public ErrorMessageResponse? ErrorMessage { get; set; } = new();







    }
}
