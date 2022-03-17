namespace DesignPatterns.Decorator.CachingSample
{
    public class CustomerRepository : ICustomerRepository
    {
        public Task<List<Customer>> GetCustomers()
        {
            return Task.FromResult(new List<Customer>()
            {
                new Customer("Fati"),
                new Customer("Steve")
            });
        }
    }
}
