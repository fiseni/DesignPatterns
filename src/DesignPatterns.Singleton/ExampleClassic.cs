namespace DesignPatterns.Singleton.Classic;

public class ExampleClassic
{
    public void Run1()
    {
        var lb1 = LoadBalancerClassic.GetLoadBalancer();
        var lb2 = LoadBalancerClassic.GetLoadBalancer();

        Console.WriteLine($"Both objects are the same instance: {lb1 == lb2}");

        for (int i = 0; i < 5; i++)
        {
            string server = lb1.Server;
            Console.WriteLine($"Dispatch request to: {server}");
        }
    }

    public void Run2()
    {
        var lb = LoadBalancerClassic.GetLoadBalancer();
        for (int i = 0; i < 5; i++)
        {
            string server = lb.Server;
            Console.WriteLine($"Dispatch request to: {server}");
        }
    }
}

public class LoadBalancerClassic
{
    static LoadBalancerClassic _instance = default!;

    Random _random = new Random();
    List<string> _servers = new List<string>();

    private static object _locker = new object();

    protected LoadBalancerClassic()
    {
        _servers.Add("Server1");
        _servers.Add("Server2");
        _servers.Add("Server3");
        _servers.Add("Server4");
        _servers.Add("Server5");
    }

    public static LoadBalancerClassic GetLoadBalancer()
    {
        if (_instance is null)
        {
            lock (_locker)
            {
                if (_instance is null)
                {
                    _instance = new LoadBalancerClassic();
                }
            }
        }

        return _instance;
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