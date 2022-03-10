using System.Reflection;

namespace DesignPatterns.Strategy.Refactored
{
    public class BalanceCalculator
    {
        // Approach 1 - Get available calculators manually
        private static List<IBalanceCalculator> GetCalculators()
        {
            return new()
            {
                PayoneerBalanceCalculator.Instance,
                LeumiBalanceCalculator.Instance,
                MasterCardBalanceCalculator.Instance
            };
        }

        // Approach 2 - Find all possible calculator implementations through reflection
        private static readonly Lazy<List<IBalanceCalculator>> Calculators =
            new Lazy<List<IBalanceCalculator>>(FindAllCalculators, LazyThreadSafetyMode.ExecutionAndPublication);
        private static List<IBalanceCalculator> FindAllCalculators()
        {
            return typeof(BalanceCalculator).Assembly
                .GetTypes()
                .Where(t => typeof(IBalanceCalculator).IsAssignableFrom(t) && typeof(IBalanceCalculator) != t)
                .SelectMany(t => t.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                                .Where(p => t.IsAssignableFrom(p.FieldType))
                                .Select(pi => (IBalanceCalculator)pi.GetValue(null)!))
                .ToList();
        }


        // Approach 3 - Register all possible calculator implementations in IoC (DI), and inject them in the constructor.
        // Your actually GetBalance method is static, so this won't work for your current code. And, you're not using DI.
        private readonly IEnumerable<IBalanceCalculator> _balanceCalculators;
        public BalanceCalculator(IEnumerable<IBalanceCalculator> balanceCalculators)
        {
            _balanceCalculators = balanceCalculators;
        }

        public static double GetBalance(double payeeId, int userId, int customerId)
        {
            // If this was not a static method, you would inject the PaymentApiProvider (or its interface better) in the constructor.
            ProviderEnums Provider = PaymentApiProvider.GetFor((decimal)payeeId);

            var calculator = Calculators.Value.FirstOrDefault(x => x.Type == Provider);

            if (calculator is null)
            {
                throw new NotImplementedException();
            }

            return calculator.GetBalance(payeeId, userId, customerId);
        }
    }
}
