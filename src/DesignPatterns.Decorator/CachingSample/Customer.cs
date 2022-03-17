namespace DesignPatterns.Decorator.CachingSample
{
    public class Customer
    {
        public string FirstName { get; set; }

        public Customer(string firstName)
        {
            FirstName = firstName;
        }
    }
}
