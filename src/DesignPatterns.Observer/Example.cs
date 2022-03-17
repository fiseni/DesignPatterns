namespace DesignPatterns.Observer.Classic;

public class Example
{
    public void Run()
    {
        var ibm = new IBM(100.00);

        var steve = new Investor() { Name = "Steve" };
        var john = new Investor() { Name = "John" };

        ibm.Subscribe(steve);
        ibm.Subscribe(john);

        ibm.Price = 100.10;
        ibm.Price = 150.10;
        ibm.Price = 130.10;

        Console.ReadLine();
    }
}

public class ChangeEventArgs : EventArgs
{
    public string? Symbol { get; set; }
    public double Price { get; set; }
}


public abstract class Stock
{
    protected string symbol;
    protected double price;

    public Stock(string symbol, double price)
    {
        this.symbol = symbol;
        this.price = price;
    }

    // Event
    public event EventHandler<ChangeEventArgs> Change = default!;

    // Invoke the Change event
    public virtual void OnChange(ChangeEventArgs e)
    {
        Change?.Invoke(this, e);
    }

    public void Subscribe(IInvestor investor)
    {
        Change += investor.Update;
    }

    public void Unsubscribe(IInvestor investor)
    {
        Change -= investor.Update;
    }

    public double Price
    {
        get { return price; }
        set
        {
            if (price != value)
            {
                price = value;
                OnChange(new ChangeEventArgs { Symbol = symbol, Price = price });
                Console.WriteLine("");
            }
        }
    }
}

public class IBM : Stock
{
    public IBM(double price)
        : base("IBM", price)
    {
    }
}

public interface IInvestor
{
    void Update(object? sender, ChangeEventArgs e);
}

public class Investor : IInvestor
{
    public string Name { get; set; } = null!;

    public Stock Stock { get; set; } = null!;

    public void Update(object? sender, ChangeEventArgs e)
    {
        Console.WriteLine("Notified {0} of {1}'s " + "change to {2:C}", Name, e.Symbol, e.Price);
    }
}