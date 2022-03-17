namespace DesignPatterns.AbstractFactory.Classic;

public class ExampleClassic
{
    public void Run()
    {
        var africa = new AfricaFactory();
        new AnimalWorld(africa).RunFoodChain();

        var america = new AmericaFactory();
        new AnimalWorld(america).RunFoodChain();
    }
}

public abstract class ContinentFactory
{
    public abstract Herbivore CreateHerbivore();
    public abstract Carnivore CreateCarnivore();
}

public class AfricaFactory : ContinentFactory
{
    public override Carnivore CreateCarnivore()
    {
        return new Lion();
    }

    public override Herbivore CreateHerbivore()
    {
        return new Wildebeest();
    }
}

public class AmericaFactory : ContinentFactory
{
    public override Carnivore CreateCarnivore()
    {
        return new Wolf();
    }

    public override Herbivore CreateHerbivore()
    {
        return new Bison();
    }
}


public abstract class Herbivore
{
}

public abstract class Carnivore
{
    public abstract void Eat(Herbivore h);
}

public class Wildebeest : Herbivore
{
}

public class Lion : Carnivore
{
    public override void Eat(Herbivore h)
    {
        Console.WriteLine($"{this.GetType().Name} eats {h.GetType().Name}");
    }
}

public class Bison : Herbivore
{
}

public class Wolf : Carnivore
{
    public override void Eat(Herbivore h)
    {
        Console.WriteLine($"{this.GetType().Name} eats {h.GetType().Name}");
    }
}

public class AnimalWorld
{
    private Herbivore _herbivore;
    private Carnivore _carnivore;

    public AnimalWorld(ContinentFactory factory)
    {
        _carnivore = factory.CreateCarnivore();
        _herbivore = factory.CreateHerbivore();
    }

    public void RunFoodChain()
    {
        _carnivore.Eat(_herbivore);
    }
}