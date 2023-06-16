using CustomerApi.Models;

namespace CustomerApi.Interfaces
{
    public interface ICustomer
    {
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
        Task AddCustomer(Customer customer);
    }
}
