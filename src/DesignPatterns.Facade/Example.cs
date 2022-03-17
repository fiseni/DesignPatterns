namespace DesignPatterns.Facade.Classic;
using static System.Console;

public class Example
{
    public void Run()
    {
        var mortgage = new Mortgage();

        var customer = new Customer() { Name = "Fati" };

        bool eligible = mortgage.IsEligible(customer, 100000);

        var result = eligible ? "Approved" : "Rejected";
        WriteLine($"{customer.Name} has been {result}.");

        WriteLine();
    }
}

public class Mortgage
{
    private readonly Bank bank = new();
    private readonly Loan loan = new();
    private readonly Credit credit = new();

    public bool IsEligible(Customer cust, int amount)
    {
        WriteLine("{0} applies for {1:C} loan\n",
            cust.Name, amount);

        bool eligible = true;

        // Check creditworthyness of applicant
        if (!bank.HasSufficientSavings(cust, amount))
        {
            eligible = false;
        }
        else if (!loan.HasNoBadLoans(cust))
        {
            eligible = false;
        }
        else if (!credit.HasGoodCredit(cust))
        {
            eligible = false;
        }

        return eligible;
    }
}

public class Customer
{
    public string Name { get; set; } = null!;
}