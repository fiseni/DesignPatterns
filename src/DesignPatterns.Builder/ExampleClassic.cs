namespace DesignPatterns.Builder.Classic;

public class ExampleClassic
{
    public void Run()
    {
        VehicleBuilder builder;

        var shop = new Shop();

        builder = new CarBuilder();
        shop.Construct(builder);
        builder.Vehicle.Show();

        builder = new MotorCycleBuilder();
        shop.Construct(builder);
        builder.Vehicle.Show();

        Console.ReadLine();
    }
}


public class Shop
{
    // Builder uses a complex series of steps
    public void Construct(VehicleBuilder vehicleBuilder)
    {
        vehicleBuilder.BuildFrame();
        vehicleBuilder.BuildEngine();
        vehicleBuilder.BuildWheels();
        vehicleBuilder.BuildDoors();
    }
}

public abstract class VehicleBuilder
{
    protected Vehicle vehicle = null!;

    // Gets vehicle instance
    public Vehicle Vehicle
    {
        get { return vehicle; }
    }

    // Abstract build methods
    public abstract void BuildFrame();
    public abstract void BuildEngine();
    public abstract void BuildWheels();
    public abstract void BuildDoors();
}

public class MotorCycleBuilder : VehicleBuilder
{
    public MotorCycleBuilder()
    {
        vehicle = new Vehicle("MotorCycle");
    }

    public override void BuildFrame()
    {
        vehicle["frame"] = "MotorCycle Frame";
    }

    public override void BuildEngine()
    {
        vehicle["engine"] = "500 cc";
    }

    public override void BuildWheels()
    {
        vehicle["wheels"] = "2";
    }

    public override void BuildDoors()
    {
        vehicle["doors"] = "0";
    }
}

public class CarBuilder : VehicleBuilder
{
    public CarBuilder()
    {
        vehicle = new Vehicle("Car");
    }

    public override void BuildFrame()
    {
        vehicle["frame"] = "Car Frame";
    }

    public override void BuildEngine()
    {
        vehicle["engine"] = "2500 cc";
    }

    public override void BuildWheels()
    {
        vehicle["wheels"] = "4";
    }

    public override void BuildDoors()
    {
        vehicle["doors"] = "4";
    }
}

public class Vehicle
{
    private readonly string vehicleType;
    private readonly Dictionary<string, string> parts = new();

    // Constructor
    public Vehicle(string vehicleType)
    {
        this.vehicleType = vehicleType;
    }

    // Indexer
    public string this[string key]
    {
        get { return parts[key]; }
        set { parts[key] = value; }
    }

    public void Show()
    {
        Console.WriteLine("\n---------------------------");
        Console.WriteLine("Vehicle Type: {0}", vehicleType);
        Console.WriteLine(" Frame  : {0}", parts["frame"]);
        Console.WriteLine(" Engine : {0}", parts["engine"]);
        Console.WriteLine(" #Wheels: {0}", parts["wheels"]);
        Console.WriteLine(" #Doors : {0}", parts["doors"]);
    }
}
