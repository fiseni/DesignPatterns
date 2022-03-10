namespace DesignPatterns.Strategy.Refactored
{
    public class PayoneerBalanceCalculator : IBalanceCalculator
    {
        public static readonly PayoneerBalanceCalculator Instance = new();
        private PayoneerBalanceCalculator() { }

        public ProviderEnums Type { get; } = ProviderEnums.Payoneer;

        public double GetBalance(double payeeId, int userId, int customerId)
        {
            //ProviderConfigurationManagerPayoneer configuration = new ProviderConfigurationManagerPayoneer();
            //configuration.setConfiguration();
            //ProviderPayoneerGetBalance providerPayoneerGetBalance = new ProviderPayoneerGetBalance((decimal)payeeId, userId, customerId, configuration);
            //var balance = providerPayoneerGetBalance.GetBalance();
            //return balance;
            return 1 + 1;
        }
    }
}
