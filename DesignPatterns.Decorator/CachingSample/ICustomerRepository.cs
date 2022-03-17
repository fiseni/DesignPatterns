
namespace DesignPatterns.Decorator.CachingSample
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomers();
    }
}