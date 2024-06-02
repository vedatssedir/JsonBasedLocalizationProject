using JsonBasedLocalizationProject.Models;

namespace JsonBasedLocalizationProject.Services
{
    public class CustomerService(IJsonErrorMessageProvider jsonErrorMessageProvider) : ICustomerService
    {
        public IJsonErrorMessageProvider JsonErrorMessageProvider { get; } = jsonErrorMessageProvider;

        public async Task<ServiceResponse<CustomerResponse>> GetCustomer()
        {
            return new ServiceResponse<CustomerResponse>() { ErrorMessage = await jsonErrorMessageProvider.GetErrorMessage("ERR001"), IsSuccessful = false };
        }


    }
}
