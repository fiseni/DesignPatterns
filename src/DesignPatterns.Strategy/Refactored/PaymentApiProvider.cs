namespace DesignPatterns.Strategy.Refactored
{
    public class PaymentApiProvider
    {
        // This is just to mimic your Project_Services.GetProviderApi((decimal)payeeId) call.
        // You may refactor that one too in the same manner.
        public static ProviderEnums GetFor(decimal payeeId)
        {
            if (payeeId == 1) return ProviderEnums.Payoneer;
            if (payeeId == 2) return ProviderEnums.Leumi;

            return ProviderEnums.Payoneer;
        }
    }
}
