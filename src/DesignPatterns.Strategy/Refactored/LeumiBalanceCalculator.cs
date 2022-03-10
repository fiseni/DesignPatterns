namespace DesignPatterns.Strategy.Refactored
{
    public class LeumiBalanceCalculator : IBalanceCalculator
    {
        public static readonly LeumiBalanceCalculator Instance = new();
        private LeumiBalanceCalculator() { }

        public ProviderEnums Type { get; } = ProviderEnums.Leumi;

        public double GetBalance(double payeeId, int userId, int customerId)
        {
            //ProviderConfigurationManagerLeumicard configuration = new ProviderConfigurationManagerLeumicard();
            //configuration.setConfiguration();
            //ProviderLeumicardGetBalance providerPayoneerGetBalance = new ProviderLeumicardGetBalance((decimal)payeeId, configuration);
            //var balance = providerPayoneerGetBalance.GetBalance();
            //return balance;

            return 2 + 2;
        }
    }
}
