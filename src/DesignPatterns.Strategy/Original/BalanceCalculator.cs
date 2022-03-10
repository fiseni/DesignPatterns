namespace DesignPatterns.Strategy.Original
{
    public class BalanceCalculator
    {
        public static double DC_Card_GetBalance(double payeeId, int userId, int customerId)
        {
            // Commenting it out so we can compile the solution.

            //try
            //{

            //    ProviderEnums Provider = Project_Services.GetProviderApi((decimal)payeeId);

            //    switch (Provider)
            //    {
            //        case ProviderEnums.Payoneer:
            //            {
            //                ProviderConfigurationManagerPayoneer configuration = new ProviderConfigurationManagerPayoneer();
            //                configuration.setConfiguration();
            //                ProviderPayoneerGetBalance providerPayoneerGetBalance = new ProviderPayoneerGetBalance((decimal)payeeId, userId, customerId, configuration);
            //                var balance = providerPayoneerGetBalance.GetBalance();
            //                return balance;

            //            }
            //        case ProviderEnums.Leumi:
            //            {
            //                ProviderConfigurationManagerLeumicard configuration = new ProviderConfigurationManagerLeumicard();
            //                configuration.setConfiguration();
            //                ProviderLeumicardGetBalance providerPayoneerGetBalance = new ProviderLeumicardGetBalance((decimal)payeeId, configuration);
            //                var balance = providerPayoneerGetBalance.GetBalance();
            //                return balance;
            //            }
            //        case ProviderEnums.Mastercard:
            //            {
            //                ProviderConfigurationManagerMastercard configuration = new ProviderConfigurationManagerMastercard();
            //                configuration.setConfiguration();
            //                ProviderMastercardGetBalance providerPayoneerGetBalance = new ProviderMastercardGetBalance((decimal)payeeId, configuration);
            //                var balance = providerPayoneerGetBalance.GetBalance();
            //                return balance;
            //            }
            //        default:
            //            {
            //                return 0;
            //            }
            //    }
            //}
            //catch (Exception exp)
            //{
            //    throw;
            //}

            return 0;
        }
    }
}
