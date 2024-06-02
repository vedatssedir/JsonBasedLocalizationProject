using JsonBasedLocalizationProject.Models;

namespace JsonBasedLocalizationProject.Services;

public interface ICustomerService
{
    Task<ServiceResponse<CustomerResponse>> GetCustomer();
}