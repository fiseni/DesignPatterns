namespace DesignPatterns.Singleton.Better;

public class ExampleBetter
{
    public void Run1()
    {
        var lb1 = LoadBalancerBetter.Instance;
        var lb2 = LoadBalancerBetter.Instance;

        Console.WriteLine($"Both objects are the same instance: {lb1 == lb2}");

        for (int i = 0; i < 5; i++)
        {
            string server = lb1.Server;
            Console.WriteLine($"Dispatch request to: {server}");
        }
    }

    public void Run2()
    {
        var lb = LoadBalancerBetter.Instance;
        for (int i = 0; i < 5; i++)
        {
            string server = lb.Server;
            Console.WriteLine($"Dispatch request to: {server}");
        }
    }
}

public class LoadBalancerBetter
{
    public static LoadBalancerBetter Instance { get; } = new();

    private readonly Random _random = new Random();
    private readonly List<string> _servers = new();

    protected LoadBalancerBetter()
    {
        _servers.Add("Server1");
        _servers.Add("Server2");
        _servers.Add("Server3");
        _servers.Add("Server4");
        _servers.Add("Server5");
    }

    public string Server
    {
        get
        {
            int r = _random.Next(_servers.Count);
            return _servers[r];
        }
    }
}