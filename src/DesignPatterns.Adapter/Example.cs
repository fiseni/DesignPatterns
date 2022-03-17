namespace DesignPatterns.Adapter;

public class Example
{
    public void Run()
    {
        // Non-adapted checmical compoung
        var unknown = new Compound();
        unknown.Display();

        // Adapted chemical compounds
        var water = new RichCompound("Water");
        water.Display();

        var benzene = new RichCompound("Benzene");
        benzene.Display();

        var ethanol = new RichCompound("Ethanol");
        ethanol.Display();
    }
}

public class Compound
{
    protected float boilingPoint;
    protected float meltingPoint;
    protected double molecularWeight;
    protected string? molecularFormula;

    public virtual void Display()
    {
        Console.WriteLine("\nCompound: Unknown ------ ");
    }
}

public class RichCompound : Compound
{
    private readonly string chemical;
    private readonly ChemicalDatabank bank;

    public RichCompound(string chemical)
    {
        this.chemical = chemical;
        this.bank = new();
    }

    public override void Display()
    {
        // The Adaptee

        boilingPoint = bank.GetCriticalPoint(chemical, "B");
        meltingPoint = bank.GetCriticalPoint(chemical, "M");
        molecularWeight = bank.GetMolecularWeight(chemical);
        molecularFormula = bank.GetMolecularStructure(chemical);

        Console.WriteLine("\nCompound: {0} ------ ", chemical);
        Console.WriteLine(" Formula: {0}", molecularFormula);
        Console.WriteLine(" Weight : {0}", molecularWeight);
        Console.WriteLine(" Melting Pt: {0}", meltingPoint);
        Console.WriteLine(" Boiling Pt: {0}", boilingPoint);
    }
}

public class ChemicalDatabank
{
    // The databank 'legacy API'
    public float GetCriticalPoint(string compound, string point)
    {
        // Melting Point
        if (point == "M")
        {
            switch (compound.ToLower())
            {
                case "water": return 0.0f;
                case "benzene": return 5.5f;
                case "ethanol": return -114.1f;
                default: return 0f;
            }
        }
        // Boiling Point
        else
        {
            switch (compound.ToLower())
            {
                case "water": return 100.0f;
                case "benzene": return 80.1f;
                case "ethanol": return 78.3f;
                default: return 0f;
            }
        }
    }

    public string GetMolecularStructure(string compound)
    {
        switch (compound.ToLower())
        {
            case "water": return "H20";
            case "benzene": return "C6H6";
            case "ethanol": return "C2H5OH";
            default: return "";
        }
    }

    public double GetMolecularWeight(string compound)
    {
        switch (compound.ToLower())
        {
            case "water": return 18.015;
            case "benzene": return 78.1134;
            case "ethanol": return 46.0688;
            default: return 0d;
        }
    }
}
