namespace DesignPatterns.Strategy.Refactored
{
    public class MasterCardBalanceCalculator : IBalanceCalculator
    {
        public static readonly MasterCardBalanceCalculator Instance = new();
        private MasterCardBalanceCalculator() { }

        public ProviderEnums Type { get; } = ProviderEnums.MasterCard;

        public double GetBalance(double payeeId, int userId, int customerId)
        {
            //ProviderConfigurationManagerMastercard configuration = new ProviderConfigurationManagerMastercard();
            //configuration.setConfiguration();
            //ProviderMastercardGetBalance providerPayoneerGetBalance = new ProviderMastercardGetBalance((decimal)payeeId, configuration);
            //var balance = providerPayoneerGetBalance.GetBalance();
            //return balance;

            return 5 + 5;
        }
    }
}
