using DesignPatterns.AbstractFactory.Better;
using DesignPatterns.AbstractFactory.Classic;

Console.WriteLine("Classic implementation!");
new ExampleClassic().Run();

Console.WriteLine();
Console.WriteLine("Improved implementation!");
new ExampleBetter().Run();