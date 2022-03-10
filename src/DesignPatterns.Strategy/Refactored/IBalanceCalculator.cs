namespace DesignPatterns.Strategy.Refactored
{
    public interface IBalanceCalculator
    {
        ProviderEnums Type { get; }

        double GetBalance(double payeeId, int userId, int customerId);
    }
}