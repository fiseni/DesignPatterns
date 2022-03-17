namespace DesignPatterns.Proxy.Classic;

public class Example
{
    public void Run()
    {
        var proxy = new MathProxy();

        // Do the math
        Console.WriteLine("4 + 2 = " + proxy.Add(4, 2));
        Console.WriteLine("4 - 2 = " + proxy.Sub(4, 2));
        Console.WriteLine("4 * 2 = " + proxy.Mul(4, 2));
        Console.WriteLine("4 / 2 = " + proxy.Div(4, 2));
    }
}

public interface IMath
{
    double Add(double x, double y);
    double Sub(double x, double y);
    double Mul(double x, double y);
    double Div(double x, double y);
}

public class Math : IMath
{
    public double Add(double x, double y) { return x + y; }
    public double Sub(double x, double y) { return x - y; }
    public double Mul(double x, double y) { return x * y; }
    public double Div(double x, double y) { return x / y; }
}

public class Math2 : IMath
{
    public double Add(double x, double y) { return x + y + 1; }
    public double Sub(double x, double y) { return x - y; }
    public double Mul(double x, double y) { return x * y; }
    public double Div(double x, double y) { return x / y; }
}

public class MathProxy : IMath
{
    private readonly Math math = new();

    public double Add(double x, double y)
    {
        return math.Add(x, y) + 1;
    }
    public double Sub(double x, double y)
    {
        return math.Sub(x, y);
    }
    public double Mul(double x, double y)
    {
        return math.Mul(x, y);
    }
    public double Div(double x, double y)
    {
        return math.Div(x, y);
    }
}