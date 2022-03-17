using DesignPatterns.Facade.Classic;

namespace DesignPatterns.Facade;

public class Bank
{
    public bool HasSufficientSavings(Customer c, int amount)
    {
        Console.WriteLine($"Check bank for {c.Name}");
        return true;
    }
}

public class Credit
{
    public bool HasGoodCredit(Customer c)
    {
        Console.WriteLine($"Check credit for {c.Name}");
        return true;
    }
}

public class Loan
{
    public bool HasNoBadLoans(Customer c)
    {
        Console.WriteLine($"Check loans for {c.Name}");
        return true;
    }
}