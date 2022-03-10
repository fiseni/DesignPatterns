namespace DesignPatterns.Builder.Optimized;

public class ExampleOptimized
{
    public void Run()
    {
        var shop = new Shop();

        shop.Construct(new CarBuilder());
        shop.ShowVehicle();

        shop.Construct(new MotorCycleBuilder());
        shop.ShowVehicle();

        Console.ReadLine();
    }
}

public class Shop
{
    private Vehicle? _vehicle;

    public void Construct(VehicleBuilder vehicleBuilder)
    {
        _vehicle = vehicleBuilder
            .BuildFrame()
            .BuildEngine()
            .BuildWheels()
            .BuildDoors()
            .Build();
    }

    public void ShowVehicle()
    {
        _vehicle?.Show();
    }
}

public abstract class VehicleBuilder
{
    public Vehicle Vehicle { get; private set; }

    public VehicleBuilder(VehicleType vehicleType)
    {
        Vehicle = new Vehicle(vehicleType);
    }

    public abstract VehicleBuilder BuildFrame();
    public abstract VehicleBuilder BuildEngine();
    public abstract VehicleBuilder BuildWheels();
    public abstract VehicleBuilder BuildDoors();

    public abstract Vehicle Build();
}

public class MotorCycleBuilder : VehicleBuilder
{
    public MotorCycleBuilder() : base(VehicleType.MotorCycle)
    {
    }

    public override MotorCycleBuilder BuildFrame()
    {
        Vehicle[PartType.Frame] = "MotorCycle Frame";
        return this;
    }
    public override MotorCycleBuilder BuildEngine()
    {
        Vehicle[PartType.Engine] = "500 cc";
        return this;
    }

    public override MotorCycleBuilder BuildWheels()
    {
        Vehicle[PartType.Wheel] = "2";
        return this;
    }

    public override MotorCycleBuilder BuildDoors()
    {
        Vehicle[PartType.Door] = "0";
        return this;

    }

    public override Vehicle Build() => Vehicle;
}

public class CarBuilder : VehicleBuilder
{
    public CarBuilder() : base(VehicleType.Car)
    {
    }

    public override CarBuilder BuildFrame()
    {
        Vehicle[PartType.Frame] = "Car Frame";
        return this;
    }

    public override CarBuilder BuildEngine()
    {
        Vehicle[PartType.Engine] = "2500 cc";
        return this;
    }

    public override CarBuilder BuildWheels()
    {
        Vehicle[PartType.Wheel] = "4";
        return this;
    }

    public override CarBuilder BuildDoors()
    {
        Vehicle[PartType.Door] = "4";
        return this;
    }

    public override Vehicle Build() => Vehicle;
}

public class Vehicle
{
    private readonly Dictionary<PartType, string> parts = new();
    private readonly VehicleType vehicleType;

    public Vehicle(VehicleType vehicleType)
    {
        this.vehicleType = vehicleType;
    }

    public string this[PartType key]
    {
        get { return parts[key]; }
        set { parts[key] = value; }
    }

    public void Show()
    {
        Console.WriteLine("\n---------------------------");
        Console.WriteLine($"Vehicle Type: {vehicleType}");
        Console.WriteLine($" Frame  : {this[PartType.Frame]}");
        Console.WriteLine($" Engine : {this[PartType.Engine]}");
        Console.WriteLine($" #Wheels: {this[PartType.Wheel]}");
        Console.WriteLine($" #Doors : {this[PartType.Door]}");
    }
}

public enum PartType
{
    Frame,
    Engine,
    Wheel,
    Door
}

public enum VehicleType
{
    Car,
    Scooter,
    MotorCycle
}
