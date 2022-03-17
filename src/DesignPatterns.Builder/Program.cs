using DesignPatterns.Builder.Classic;
using DesignPatterns.Builder.Better;

Console.WriteLine("The classic builder implementation");
new ExampleClassic().Run();

Console.WriteLine();

Console.WriteLine("The improved builder implementation");
new ExampleBetter().Run();