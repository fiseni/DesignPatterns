using DesignPatterns.Decorator.Better;
using DesignPatterns.Decorator.CachingSample;
using DesignPatterns.Decorator.Classic;

new ExampleClassic().Run();
new ExampleBetter().Run();

// -----------------------------------------------------------------

var services = new ServiceCollection();
services.AddScoped<CustomerRepository>();

// Read it from config file?
var isCachingEnabled = true;

if (isCachingEnabled == true)
{
    services.AddScoped<ICustomerRepository, CustomerCachedRepository>();
}
else
{
    services.AddScoped<ICustomerRepository, CustomerRepository>();
}