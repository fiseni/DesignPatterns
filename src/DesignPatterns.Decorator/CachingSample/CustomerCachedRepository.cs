using Microsoft.Extensions.Caching.Memory;

namespace DesignPatterns.Decorator.CachingSample
{
    public class CustomerCachedRepository : ICustomerRepository
    {
        private static readonly TimeSpan DefaultCacheDuration = TimeSpan.FromMinutes(2);
        private static readonly string _cacheKey = "customers";

        private readonly IMemoryCache _cache;
        private readonly CustomerRepository _customerRepository;

        public CustomerCachedRepository(IMemoryCache cache, CustomerRepository customerRepository)
        {
            _cache = cache;
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _cache.GetOrCreateAsync(_cacheKey, async entry =>
            {
                entry.SlidingExpiration = DefaultCacheDuration;
                entry.AbsoluteExpirationRelativeToNow = DefaultCacheDuration;
                return await _customerRepository.GetCustomers();
            });
        }
    }
}
