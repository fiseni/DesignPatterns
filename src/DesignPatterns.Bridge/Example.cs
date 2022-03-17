namespace DesignPatterns.Bridge;

public class Example
{
    public void Run()
    {
        var customers = new Customers(new CustomersData("Chicago"));

        customers.Show();
        customers.Next();
        customers.Show();
        customers.Next();
        customers.Show();

        customers.ShowAll();
    }
}

public class CustomersBase
{
    private readonly IDataObject<string> dataObject;

    public CustomersBase(IDataObject<string> dataObject)
    {
        this.dataObject = dataObject;
    }

    public virtual void Next() => dataObject.NextRecord();
    public virtual void Prior() => dataObject.PriorRecord();
    public virtual void Add(string name) => dataObject.AddRecord(name);
    public virtual void Delete(string name) => dataObject.DeleteRecord(name);
    public virtual void Show() => dataObject.ShowRecord();
    public virtual void ShowAll() => dataObject.ShowAllRecords();
}

public class Customers : CustomersBase
{
    public Customers(IDataObject<string> dataObject) :
        base(dataObject)
    {
    }

    public override void ShowAll()
    {
        Console.WriteLine();
        Console.WriteLine("------------------------");
        base.ShowAll();
        Console.WriteLine("------------------------");
    }
}


public interface IDataObject<T>
{
    void NextRecord();
    void PriorRecord();
    void AddRecord(T t);
    void DeleteRecord(T t);
    T GetCurrentRecord();
    void ShowRecord();
    void ShowAllRecords();
}

public class CustomersData : IDataObject<string>
{
    private readonly string city;
    private readonly List<string> customers;
    private int current = 0;

    // Constructor
    public CustomersData(string city)
    {
        this.city = city;

        // Simulate loading from database
        customers = new List<string>
              { "Jim Jones", "Samual Jackson", "Allan Good",
                "Ann Stills", "Lisa Giolani" };
    }

    public void NextRecord()
    {
        if (current <= customers.Count - 1)
        {
            current++;
        }
    }

    public void PriorRecord()
    {
        if (current > 0)
        {
            current--;
        }
    }

    public void AddRecord(string customer) =>
        customers.Add(customer);

    public void DeleteRecord(string customer) =>
        customers.Remove(customer);

    public string GetCurrentRecord() =>
        customers[current];

    public void ShowRecord() =>
        Console.WriteLine(customers[current]);

    public void ShowAllRecords()
    {
        Console.WriteLine("Customer Group: " + city);
        customers.ForEach(customer => Console.WriteLine(" " + customer));
    }
}
